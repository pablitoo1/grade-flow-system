using System.ComponentModel.DataAnnotations;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.DTO.Grade;

public class GradeRequest
{
    public required GradeType gradeType { get; set; }
    public DateTime dateAssigned { get; set; }
    public string? comments { get; set; }
    public required Student student { get; set; }
    public required Subject subject { get; set; }
}
