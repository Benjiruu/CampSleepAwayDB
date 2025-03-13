using Microsoft.EntityFrameworkCore;

public class CampContext : DbContext
{
    public DbSet<Camper> Campers { get; set; }
    public DbSet<NextOfKin> NextOfKins { get; set; }
    public DbSet<Counselor> Counselors { get; set; }
    public DbSet<Cabin> Cabins { get; set; }
    public DbSet<CamperCabinAssignment> CamperCabinAssignments { get; set; }
    public DbSet<CounselorCabinAssignment> CounselorCabinAssignments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CampDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Camper>()
            .HasMany(c => c.CamperCabinAssignments)
            .WithOne(ca => ca.Camper)
            .HasForeignKey(ca => ca.CamperId);

        modelBuilder.Entity<Counselor>()
            .HasMany(c => c.CounselorCabinAssignments)
            .WithOne(ca => ca.Counselor)
            .HasForeignKey(ca => ca.CounselorId);

        modelBuilder.Entity<Cabin>()
            .HasMany(c => c.CamperCabinAssignments)
            .WithOne(ca => ca.Cabin)
            .HasForeignKey(ca => ca.CabinId);

        modelBuilder.Entity<Cabin>()
            .HasMany(c => c.CounselorCabinAssignments)
            .WithOne(ca => ca.Cabin)
            .HasForeignKey(ca => ca.CabinId);

        modelBuilder.Entity<NextOfKin>()
            .HasOne(n => n.Camper)
            .WithMany(c => c.NextOfKins)
            .HasForeignKey(n => n.CamperId);

        // Seed data
        modelBuilder.Entity<Cabin>().HasData(
            new Cabin { CabinId = 1, Name = "Pine Lodge", MaxCapacity = 4 },
            new Cabin { CabinId = 2, Name = "Maple Retreat", MaxCapacity = 4 },
            new Cabin { CabinId = 3, Name = "Oak Haven", MaxCapacity = 4 }
        );

        modelBuilder.Entity<Counselor>().HasData(
            new Counselor { CounselorId = 1, Name = "John Smith", EmploymentDate = new DateTime(2023, 1, 1) },
            new Counselor { CounselorId = 2, Name = "Jane Doe", EmploymentDate = new DateTime(2023, 1, 1) },
            new Counselor { CounselorId = 3, Name = "Emily Johnson", EmploymentDate = new DateTime(2023, 1, 1) }
        );

        modelBuilder.Entity<Camper>().HasData(
            new Camper { CamperId = 1, Name = "Alice Brown" },
            new Camper { CamperId = 2, Name = "Bob White" },
            new Camper { CamperId = 3, Name = "Charlie Green" },
            new Camper { CamperId = 4, Name = "Daisy Blue" },
            new Camper { CamperId = 5, Name = "Ethan Black" },
            new Camper { CamperId = 6, Name = "Fiona Gray" },
            new Camper { CamperId = 7, Name = "George Red" },
            new Camper { CamperId = 8, Name = "Hannah Yellow" },
            new Camper { CamperId = 9, Name = "Ian Purple" },
            new Camper { CamperId = 10, Name = "Jack Orange" },
            new Camper { CamperId = 11, Name = "Katie Pink" },
            new Camper { CamperId = 12, Name = "Liam Cyan" }
        );

        modelBuilder.Entity<NextOfKin>().HasData(
            new NextOfKin { NextOfKinId = 1, Name = "Sarah Brown", Relationship = "Parent", CamperId = 1 },
            new NextOfKin { NextOfKinId = 2, Name = "Tom White", Relationship = "Parent", CamperId = 2 },
            new NextOfKin { NextOfKinId = 3, Name = "Ursula Green", Relationship = "Parent", CamperId = 3 },
            new NextOfKin { NextOfKinId = 4, Name = "Victor Blue", Relationship = "Parent", CamperId = 4 }
        );

        modelBuilder.Entity<CamperCabinAssignment>().HasData(
            new CamperCabinAssignment { Id = 1, CamperId = 1, CabinId = 1, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 2, CamperId = 2, CabinId = 1, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 3, CamperId = 3, CabinId = 1, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 4, CamperId = 4, CabinId = 1, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 5, CamperId = 5, CabinId = 2, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 6, CamperId = 6, CabinId = 2, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 7, CamperId = 7, CabinId = 2, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 8, CamperId = 8, CabinId = 2, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 9, CamperId = 9, CabinId = 3, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 10, CamperId = 10, CabinId = 3, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 11, CamperId = 11, CabinId = 3, StartDate = new DateTime(2023, 6, 1) },
            new CamperCabinAssignment { Id = 12, CamperId = 12, CabinId = 3, StartDate = new DateTime(2023, 6, 1) }
        );

        modelBuilder.Entity<CounselorCabinAssignment>().HasData(
            new CounselorCabinAssignment { Id = 1, CounselorId = 1, CabinId = 1, StartDate = new DateTime(2023, 6, 1) },
            new CounselorCabinAssignment { Id = 2, CounselorId = 2, CabinId = 2, StartDate = new DateTime(2023, 6, 1) },
            new CounselorCabinAssignment { Id = 3, CounselorId = 3, CabinId = 3, StartDate = new DateTime(2023, 6, 1) }
        );
    }
}

