using grade_flow_system.Models.DTO.Grade;

namespace grade_flow_system.Models.DTO.Subject;

public class SubjectRequest
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<GradeResponse> Grades { get; set; }
}
