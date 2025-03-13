using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Camper
{
    [Key]
    public int CamperId { get; set; }
    [Required]
    public string Name { get; set; }
    public List<NextOfKin> NextOfKins { get; set; }
    public List<CamperCabinAssignment> CamperCabinAssignments { get; set; }
}

public class NextOfKin
{
    [Key]
    public int NextOfKinId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Relationship { get; set; }
    public int CamperId { get; set; }
    public Camper Camper { get; set; }
}

public class Counselor
{
    [Key]
    public int CounselorId { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime EmploymentDate { get; set; }
    public List<CounselorCabinAssignment> CounselorCabinAssignments { get; set; }
}

public class Cabin
{
    [Key]
    public int CabinId { get; set; }
    [Required]
    public string Name { get; set; }
    public int MaxCapacity { get; set; } = 4;
    public List<CamperCabinAssignment> CamperCabinAssignments { get; set; }
    public List<CounselorCabinAssignment> CounselorCabinAssignments { get; set; }
}

public class CamperCabinAssignment
{
    [Key]
    public int Id { get; set; }
    public int CamperId { get; set; }
    public Camper Camper { get; set; }
    public int CabinId { get; set; }
    public Cabin Cabin { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class CounselorCabinAssignment
{
    [Key]
    public int Id { get; set; }
    public int CounselorId { get; set; }
    public Counselor Counselor { get; set; }
    public int CabinId { get; set; }
    public Cabin Cabin { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
