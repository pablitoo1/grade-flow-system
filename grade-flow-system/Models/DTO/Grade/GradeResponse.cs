using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.DTO.Grade;

public class GradeResponse
{
    public int Id { get; set; }
    public required GradeTypeResponse GradeType { get; set; }
    public DateTime DateAssigned { get; set; }
    public string? Comments { get; set; }
    public required StudentResponse Student { get; set; }
    public required SubjectResponse Subject { get; set; }
}
