using System.ComponentModel.DataAnnotations;

namespace grade_flow_system.Models.Entity;

public class StudentsGroup
{
    [Key] public int Id { get; set; }
    [Required][MaxLength(50)] public required string Name { get; set; }
    public ICollection<Student> Students { get; set; }
}
