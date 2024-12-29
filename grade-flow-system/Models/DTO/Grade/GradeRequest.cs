using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.DTO.Grade;

public class GradeRequest
{
    public required int GradeTypeId { get; set; }
    public DateTime DateAssigned { get; set; }
    public string? Comments { get; set; }
    public required int StudentId { get; set; }
    public required int SubjectId { get; set; }
}
