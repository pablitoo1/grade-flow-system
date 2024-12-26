using System.ComponentModel.DataAnnotations;

namespace grade_flow_system.Models.Entity;

public class Subject
{
    [Key] public int Id { get; set; }
    [Required][MaxLength(100)] public required string Name { get; set; }
    [MaxLength(500)] public string? Description { get; set; }
    public ICollection<Grade>? Grades { get; set; }
}
