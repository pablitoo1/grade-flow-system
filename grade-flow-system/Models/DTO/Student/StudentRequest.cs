﻿using grade_flow_system.Models.DTO.Grade;

namespace grade_flow_system.Models.DTO.Student;

public class StudentRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public ICollection<GradeResponse> Grades { get; set; }
}
