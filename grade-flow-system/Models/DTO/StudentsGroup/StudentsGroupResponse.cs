using grade_flow_system.Models.DTO.Student;

namespace grade_flow_system.Models.DTO.StudentsGroup;

public class StudentsGroupResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<StudentResponse> Students { get; set; }
}
