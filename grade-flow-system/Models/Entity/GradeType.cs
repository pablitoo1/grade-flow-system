using System.ComponentModel.DataAnnotations;

namespace grade_flow_system.Models.Entity;

public class GradeType
{
    [Key] public int Id { get; set; }
    [Required] public double Value { get; set; }
    [MaxLength(50)] public string? Description { get; set; }
}
