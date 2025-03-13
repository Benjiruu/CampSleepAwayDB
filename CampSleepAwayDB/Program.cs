using System;
using System.Linq;
using ConsoleTools;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new CampContext())
        {
            context.Database.EnsureCreated();

            var camperMenu = new ConsoleMenu(args, level: 1)
                .Add("List all campers", () => ListAllCampers(context))
                .Add("Add a new camper", () => AddNewCamper(context))
                .Add("Update a camper", () => UpdateCamper(context))
                .Add("Delete a camper", () => DeleteCamper(context))
                .Add("Assign camper to cabin", () => AssignCamperToCabin(context))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                   {
                       config.Selector = ">> ";
                       config.Title = "Campers";
                       config.EnableBreadcrumb = true;
                   });

            var counselorMenu = new ConsoleMenu(args, level: 1)
                .Add("List all counselors", () => ListAllCounselors(context))
                .Add("Add a new counselor", () => AddNewCounselor(context))
                .Add("Update a counselor", () => UpdateCounselor(context))
                .Add("Delete a counselor", () => DeleteCounselor(context))
                .Add("Assign counselor to cabin", () => AssignCounselorToCabin(context))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                     {
                         config.Selector = ">> ";
                         config.Title = "Counselors";
                         config.EnableBreadcrumb = true;
                     });

            var cabinMenu = new ConsoleMenu(args, level: 1)
                .Add("List all cabins", () => ListAllCabins(context))
                .Add("Add a new cabin", () => AddNewCabin(context))
                .Add("Update a cabin", () => UpdateCabin(context))
                .Add("Delete a cabin", () => DeleteCabin(context))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                     {
                         config.Selector = ">> ";
                         config.Title = "Cabins";
                         config.EnableBreadcrumb = true;
                     });

            var nextOfKinMenu = new ConsoleMenu(args, level: 1)
                .Add("List all next of kin", () => ListAllNextOfKin(context))
                .Add("Add a new next of kin", () => AddNewNextOfKin(context))
                .Add("Update a next of kin", () => UpdateNextOfKin(context))
                .Add("Delete a next of kin", () => DeleteNextOfKin(context))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                    {
                       config.Selector = ">> ";
                       config.Title = "Next Of Kin";
                       config.EnableBreadcrumb = true;
                    });

            var reportMenu = new ConsoleMenu(args, level: 1)
                .Add("Report: Campers by cabin or counselor", () => ReportCampersByCabinOrCounselor(context))
                .Add("Report: Campers with next of kin by cabin", () => ReportCampersWithNextOfKinByCabin(context))
                .Add("Search campers by cabin or counselor", () => ReportCampersByCabinOrCounselorWithUI(context))
                .Add("Back", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = ">> ";
                    config.Title = "Reports";
                    config.EnableBreadcrumb = true;
                });

            var mainMenu = new ConsoleMenu(args, level: 0)
                .Add("Campers", camperMenu.Show)
                .Add("Counselors", counselorMenu.Show)
                .Add("Cabins", cabinMenu.Show)
                .Add("Next of Kin", nextOfKinMenu.Show)
                .Add("Reports", reportMenu.Show)
                .Add("Exit", ConsoleMenu.Close)
                .Configure(config =>
                {
                    config.Selector = ">> ";
                    config.Title = "Camp SleepAway Management System";
                    config.EnableBreadcrumb = true;
                });

            mainMenu.Show();
        }
    }

    static void ListAllCampers(CampContext context)
    {
        var campers = context.Campers
            .Include(c => c.CamperCabinAssignments)
                .ThenInclude(ca => ca.Cabin)
            .ToList();

        foreach (var camper in campers)
        {
            var currentAssignment = camper.CamperCabinAssignments.FirstOrDefault(ca => ca.EndDate == null);
            var cabinName = currentAssignment?.Cabin?.Name ?? "No cabin assigned";
            Console.WriteLine($"CamperId: {camper.CamperId} - {camper.Name}, Cabin: {cabinName}");
        }
        Console.ReadKey();
    }

    static void AddNewCamper(CampContext context)
    {
        Console.Write("Enter camper name: ");
        var name = Console.ReadLine();
        var camper = new Camper { Name = name };
        context.Campers.Add(camper);
        context.SaveChanges();
        Console.WriteLine("Camper added successfully.");
        Console.ReadKey();
    }

    static void UpdateCamper(CampContext context)
    {
        try
        {
            ListAllCampers(context);
            Console.Write("Enter camper ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int camperId))
            {
                var camper = context.Campers.Find(camperId);
                if (camper != null)
                {
                    Console.Write("Enter new camper name: ");
                    camper.Name = Console.ReadLine();

                    var assignment = context.CamperCabinAssignments.FirstOrDefault(ca => ca.CamperId == camperId && ca.EndDate == null);
                    if (assignment != null)
                    {
                        Console.Write("Enter new start date (yyyy-mm-dd): ");
                        assignment.StartDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter new end date (yyyy-mm-dd) or leave empty if still active: ");
                        var endDateInput = Console.ReadLine();
                        assignment.EndDate = string.IsNullOrEmpty(endDateInput) ? (DateTime?)null : DateTime.Parse(endDateInput);
                    }

                    context.SaveChanges();
                    Console.WriteLine("Camper updated successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Camper not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid camper ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void DeleteCamper(CampContext context)
    {
        try
        {
            ListAllCampers(context);
            Console.Write("Enter camper ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int camperId))
            {
                var camper = context.Campers.Find(camperId);
                if (camper != null)
                {
                    context.Campers.Remove(camper);
                    context.SaveChanges();
                    Console.WriteLine("Camper deleted successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Camper not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid camper ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void ListAllCounselors(CampContext context)
    {
        var counselors = context.Counselors
            .Include(c => c.CounselorCabinAssignments)
                .ThenInclude(ca => ca.Cabin)
            .ToList();

        foreach (var counselor in counselors)
        {
            var currentAssignment = counselor.CounselorCabinAssignments.FirstOrDefault(ca => ca.EndDate == null);
            var cabinName = currentAssignment?.Cabin?.Name ?? "No cabin assigned";
            Console.WriteLine($"CounselorId: {counselor.CounselorId} - {counselor.Name}, Employment Date: {counselor.EmploymentDate}, Cabin: {cabinName}");
        }
        Console.ReadKey();
    }

    static void AddNewCounselor(CampContext context)
    {
        Console.Write("Enter counselor name: ");
        var name = Console.ReadLine();
        Console.Write("Enter counselor employment date (yyyy-mm-dd): ");
        var employmentDate = DateTime.Parse(Console.ReadLine());
        var counselor = new Counselor { Name = name, EmploymentDate = employmentDate };
        context.Counselors.Add(counselor);
        context.SaveChanges();
        Console.WriteLine("Counselor added successfully.");
        Console.ReadKey();
    }

    static void UpdateCounselor(CampContext context)
    {
        try
        {
            ListAllCounselors(context);
            Console.Write("Enter counselor ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int counselorId))
            {
                var counselor = context.Counselors.Find(counselorId);
                if (counselor != null)
                {
                    Console.Write("Enter new counselor name: ");
                    counselor.Name = Console.ReadLine();

                    var assignment = context.CounselorCabinAssignments.FirstOrDefault(ca => ca.CounselorId == counselorId && ca.EndDate == null);
                    if (assignment != null)
                    {
                        Console.Write("Enter new start date (yyyy-mm-dd): ");
                        assignment.StartDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Enter new end date (yyyy-mm-dd) or leave empty if still active: ");
                        var endDateInput = Console.ReadLine();
                        assignment.EndDate = string.IsNullOrEmpty(endDateInput) ? (DateTime?)null : DateTime.Parse(endDateInput);
                    }

                    context.SaveChanges();
                    Console.WriteLine("Counselor updated successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Counselor not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid counselor ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void DeleteCounselor(CampContext context)
    {
        try
        {
            ListAllCounselors(context);
            Console.Write("Enter counselor ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int counselorId))
            {
                var counselor = context.Counselors.Find(counselorId);
                if (counselor != null)
                {
                    context.Counselors.Remove(counselor);
                    context.SaveChanges();
                    Console.WriteLine("Counselor deleted successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Counselor not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid counselor ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void ListAllCabins(CampContext context)
    {
        var cabins = context.Cabins.ToList();
        foreach (var cabin in cabins)
        {
            Console.WriteLine($"Cabin: {cabin.CabinId} - {cabin.Name}, Max Capacity: {cabin.MaxCapacity}");
        }
        Console.ReadKey();
    }

    static void AddNewCabin(CampContext context)
    {
        Console.Write("Enter cabin name: ");
        var name = Console.ReadLine();
        Console.Write("Enter cabin max capacity: ");
        var maxCapacity = int.Parse(Console.ReadLine());
        var cabin = new Cabin { Name = name, MaxCapacity = maxCapacity };
        context.Cabins.Add(cabin);
        context.SaveChanges();
        Console.WriteLine("Cabin added successfully.");
        Console.ReadKey();
    }

    static void UpdateCabin(CampContext context)
    {
        try
        {
            ListAllCabins(context);
            Console.Write("Enter cabin ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int cabinId))
            {
                var cabin = context.Cabins.Find(cabinId);
                if (cabin != null)
                {
                    Console.Write("Enter new cabin name: ");
                    cabin.Name = Console.ReadLine();
                    Console.Write("Enter new cabin max capacity: ");
                    cabin.MaxCapacity = int.Parse(Console.ReadLine());
                    context.SaveChanges();
                    Console.WriteLine("Cabin updated successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Cabin not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid cabin ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void DeleteCabin(CampContext context)
    {
        try
        {
            ListAllCabins(context);
            Console.Write("Enter cabin ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int cabinId))
            {
                var cabin = context.Cabins.Find(cabinId);
                if (cabin != null)
                {
                    context.Cabins.Remove(cabin);
                    context.SaveChanges();
                    Console.WriteLine("Cabin deleted successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Cabin not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid cabin ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ListAllNextOfKin(CampContext context)
    {
        var nextOfKins = context.NextOfKins.ToList();
        foreach (var nextOfKin in nextOfKins)
        {
            Console.WriteLine($"NextOfKin: {nextOfKin.NextOfKinId} - {nextOfKin.Name}, Relationship: {nextOfKin.Relationship}, Campers Name: {nextOfKin.Name}");
        }
        Console.ReadKey();
    }

    static void AddNewNextOfKin(CampContext context)
    {
        Console.Write("Enter camper ID: ");
        var camperId = int.Parse(Console.ReadLine());
        Console.Write("Enter next of kin name: ");
        var name = Console.ReadLine();
        Console.Write("Enter relationship: ");
        var relationship = Console.ReadLine();
        var nextOfKin = new NextOfKin { CamperId = camperId, Name = name, Relationship = relationship };
        context.NextOfKins.Add(nextOfKin);
        context.SaveChanges();
        Console.WriteLine("Next of kin added successfully.");
        Console.ReadKey();
    }

    static void UpdateNextOfKin(CampContext context)
    {
        try
        {
            ListAllNextOfKin(context);
            Console.Write("Enter next of kin ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int nextOfKinId))
            {
                var nextOfKin = context.NextOfKins.Find(nextOfKinId);
                if (nextOfKin != null)
                {
                    Console.Write("Enter new next of kin name: ");
                    nextOfKin.Name = Console.ReadLine();
                    Console.Write("Enter new relationship: ");
                    nextOfKin.Relationship = Console.ReadLine();
                    context.SaveChanges();
                    Console.WriteLine("Next of kin updated successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Next of kin not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid next of kin ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void DeleteNextOfKin(CampContext context)
    {
        try
        {
            ListAllNextOfKin(context);
            Console.Write("Enter next of kin ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int nextOfKinId))
            {
                var nextOfKin = context.NextOfKins.Find(nextOfKinId);
                if (nextOfKin != null)
                {
                    context.NextOfKins.Remove(nextOfKin);
                    context.SaveChanges();
                    Console.WriteLine("Next of kin deleted successfully.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Next of kin not found.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid next of kin ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void AssignCamperToCabin(CampContext context)
    {
        try
        {
            ListAllCampers(context);
            Console.Write("Enter camper ID to assign: ");
            if (int.TryParse(Console.ReadLine(), out int camperId))
            {
                ListAllCabins(context);
                Console.Write("Enter cabin ID to assign to: ");
                if (int.TryParse(Console.ReadLine(), out int cabinId))
                {
                    var camper = context.Campers
                        .Include(c => c.CamperCabinAssignments)
                        .FirstOrDefault(c => c.CamperId == camperId);
                    var cabin = context.Cabins
                        .Include(c => c.CamperCabinAssignments)
                        .Include(c => c.CounselorCabinAssignments)
                        .FirstOrDefault(c => c.CabinId == cabinId);

                    if (camper != null && cabin != null)
                    {
                        var counselorAssigned = cabin.CounselorCabinAssignments.Any(ca => ca.EndDate == null);
                        if (counselorAssigned)
                        {
                            if (cabin.CamperCabinAssignments.Count(ca => ca.EndDate == null) < cabin.MaxCapacity)
                            {
                                var currentAssignment = camper.CamperCabinAssignments.FirstOrDefault(ca => ca.EndDate == null);
                                if (currentAssignment != null)
                                {
                                    currentAssignment.EndDate = DateTime.Now;
                                }

                                var assignment = new CamperCabinAssignment
                                {
                                    CamperId = camperId,
                                    CabinId = cabinId,
                                    StartDate = DateTime.Now
                                };
                                context.CamperCabinAssignments.Add(assignment);
                                context.SaveChanges();
                                Console.WriteLine("Camper assigned to cabin successfully.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Cannot assign camper to cabin. The cabin is at full capacity.");
                                Console.ReadKey();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cannot assign camper to cabin without an assigned counselor. Please assign a counselor to the cabin first.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid camper ID or cabin ID.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid cabin ID.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid camper ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void AssignCounselorToCabin(CampContext context)
    {
        try
        {
            ListAllCounselors(context);
            Console.Write("Enter counselor ID to assign: ");
            if (int.TryParse(Console.ReadLine(), out int counselorId))
            {
                ListAllCabins(context);
                Console.Write("Enter cabin ID to assign to: ");
                if (int.TryParse(Console.ReadLine(), out int cabinId))
                {
                    var counselor = context.Counselors.Find(counselorId);
                    var cabin = context.Cabins.Find(cabinId);

                    if (counselor != null && cabin != null)
                    {
                        var assignment = new CounselorCabinAssignment
                        {
                            CounselorId = counselorId,
                            CabinId = cabinId,
                            StartDate = DateTime.Now
                        };
                        context.CounselorCabinAssignments.Add(assignment);
                        context.SaveChanges();
                        Console.WriteLine("Counselor assigned to cabin successfully.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Invalid counselor ID or cabin ID.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid cabin ID.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid counselor ID.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void ReportCampersByCabinOrCounselor(CampContext context)
    {
        try
        {
            var cabins = context.Cabins
                .Include(c => c.CamperCabinAssignments)
                    .ThenInclude(ca => ca.Camper)
                .Include(c => c.CounselorCabinAssignments)
                    .ThenInclude(ca => ca.Counselor)
                .ToList();

            if (cabins == null || !cabins.Any())
            {
                Console.WriteLine("No cabins found.");
                return;
            }

            foreach (var cabin in cabins)
            {
                var counselorAssignment = cabin.CounselorCabinAssignments
                    .FirstOrDefault(ca => ca.EndDate == null);
                var counselorName = counselorAssignment?.Counselor?.Name ?? "No counselor assigned";
                Console.WriteLine($"Cabin: {cabin.Name}, Counselor: {counselorName}");

                var camperAssignments = cabin.CamperCabinAssignments
                    .Where(ca => ca.EndDate == null).ToList();
                if (camperAssignments.Any())
                {
                    foreach (var camperAssignment in camperAssignments)
                    {
                        Console.WriteLine($"  Camper: {camperAssignment.Camper.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("  No campers assigned to this cabin.");
                }

                if (counselorAssignment == null)
                {
                    Console.WriteLine("  Warning: This cabin has no counselor!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        Console.ReadKey();
    }

    static void ReportCampersWithNextOfKinByCabin(CampContext context)
    {
        try
        {
            var cabins = context.Cabins
                .Include(c => c.CamperCabinAssignments)
                    .ThenInclude(ca => ca.Camper)
                        .ThenInclude(c => c.NextOfKins)
                .ToList();

            if (cabins == null || !cabins.Any())
            {
                Console.WriteLine("No cabins found.");
                return;
            }

            foreach (var cabin in cabins)
            {
                Console.WriteLine($"Cabin: {cabin.Name}");
                var camperAssignments = cabin.CamperCabinAssignments
                    .Where(ca => ca.EndDate == null).ToList();
                if (camperAssignments.Any())
                {
                    foreach (var camperAssignment in camperAssignments)
                    {
                        Console.WriteLine($"  Camper: {camperAssignment.Camper.Name}");
                        foreach (var nextOfKin in camperAssignment.Camper.NextOfKins)
                        {
                            Console.WriteLine($"    NextOfKin: {nextOfKin.Name}, Relationship: {nextOfKin.Relationship}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  No campers assigned to this cabin.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        Console.ReadKey();
    }
    static void ReportCampersByCabinOrCounselorWithUI(CampContext context)
    {
        try
        {
            Console.WriteLine("Search campers by:");
            Console.WriteLine("1. Cabin");
            Console.WriteLine("2. Counselor");
            Console.Write("Enter your choice (1 or 2): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                ListAllCabins(context);
                Console.Write("Enter cabin ID to search: ");
                if (int.TryParse(Console.ReadLine(), out int cabinId))
                {
                    var cabin = context.Cabins
                        .Include(c => c.CamperCabinAssignments)
                            .ThenInclude(ca => ca.Camper)
                        .Include(c => c.CounselorCabinAssignments)
                            .ThenInclude(ca => ca.Counselor)
                        .FirstOrDefault(c => c.CabinId == cabinId);

                    if (cabin != null)
                    {
                        var counselorAssignment = cabin.CounselorCabinAssignments
                            .FirstOrDefault(ca => ca.EndDate == null);
                        var counselorName = counselorAssignment?.Counselor?.Name ?? "No counselor assigned";
                        Console.WriteLine($"Cabin: {cabin.Name}, Counselor: {counselorName}");

                        var camperAssignments = cabin.CamperCabinAssignments
                            .Where(ca => ca.EndDate == null).ToList();
                        if (camperAssignments.Any())
                        {
                            foreach (var camperAssignment in camperAssignments)
                            {
                                Console.WriteLine($"  Camper: {camperAssignment.Camper.Name}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("  No campers assigned to this cabin.");
                        }

                        if (counselorAssignment == null)
                        {
                            Console.WriteLine("  Warning: This cabin has no counselor!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Cabin not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid cabin ID.");
                }
            }
            else if (choice == "2")
            {
                ListAllCounselors(context);
                Console.Write("Enter counselor ID to search: ");
                if (int.TryParse(Console.ReadLine(), out int counselorId))
                {
                    var counselor = context.Counselors
                        .Include(c => c.CounselorCabinAssignments)
                            .ThenInclude(ca => ca.Cabin)
                                .ThenInclude(c => c.CamperCabinAssignments)
                                    .ThenInclude(ca => ca.Camper)
                        .FirstOrDefault(c => c.CounselorId == counselorId);

                    if (counselor != null)
                    {
                        Console.WriteLine($"Counselor: {counselor.Name}, Employment Date: {counselor.EmploymentDate}");
                        var cabinAssignments = counselor.CounselorCabinAssignments
                            .Where(ca => ca.EndDate == null).ToList();
                        if (cabinAssignments.Any())
                        {
                            foreach (var cabinAssignment in cabinAssignments)
                            {
                                Console.WriteLine($"  Cabin: {cabinAssignment.Cabin.Name}");
                                var camperAssignments = cabinAssignment.Cabin.CamperCabinAssignments
                                    .Where(ca => ca.EndDate == null).ToList();
                                if (camperAssignments.Any())
                                {
                                    foreach (var camperAssignment in camperAssignments)
                                    {
                                        Console.WriteLine($"    Camper: {camperAssignment.Camper.Name}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("    No campers assigned to this cabin.");
                                    Console.ReadKey();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("  No cabins assigned to this counselor.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Counselor not found.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid counselor ID.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        Console.ReadKey();
    }
}
