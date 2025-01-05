namespace grade_flow_system.Models.DTO.Teacher;

public class TeacherRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
}
