using System.ComponentModel.DataAnnotations;

namespace grade_flow_system.Models.Entity;

public class Grade
{
    [Key] public int Id { get; set; }
    public double value { get; set; }
}
