using System.ComponentModel.DataAnnotations;

namespace grade_flow_system.Models.Entity;

public class Teacher
{
    [Key] public int Id { get; set; }
    [Required][MaxLength(100)] public required string FirstName { get; set; }
    [Required][MaxLength(100)] public required string LastName { get; set; }
    [MaxLength(100)] public string? Email { get; set; }
    public ICollection<Subject>? Subjects { get; set; }
}
