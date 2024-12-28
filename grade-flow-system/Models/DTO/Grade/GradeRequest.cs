using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.DTO.Grade;

public class GradeRequest
{
    public required int gradeTypeId { get; set; }
    public DateTime dateAssigned { get; set; }
    public string? comments { get; set; }
    public required int studentId { get; set; }
    public required int subjectId { get; set; }
}
