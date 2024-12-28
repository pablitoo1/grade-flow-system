using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.DTO.Grade;

public class GradeResponse
{
    public int id { get; set; }
    public required GradeTypeResponse gradeType { get; set; }
    public DateTime dateAssigned { get; set; }
    public string? comments { get; set; }
    public required Student student { get; set; }
    public required Subject subject { get; set; }
}
