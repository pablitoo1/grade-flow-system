using grade_flow_system.Models.DTO.Subject;

namespace grade_flow_system.Models.DTO.Teacher;

public class TeacherResponse
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public ICollection<SubjectResponse> Subjects { get; set; }
}
