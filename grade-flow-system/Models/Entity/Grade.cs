﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace grade_flow_system.Models.Entity;

public class Grade
{
    [Key] public int Id { get; set; }
    [Required] public int GradeTypeId { get; set; }
    [ForeignKey("GradeTypeId")] public GradeType GradeType { get; set; }
    public DateTime DateAssigned { get; set; }
    [MaxLength(500)] public string? Comments { get; set; }
    [Required] public int StudentId { get; set; }
    [ForeignKey("StudentId")] public Student Student { get; set; }
    [Required] public int SubjectId { get; set; }
    [ForeignKey("SubjectId")] public Subject Subject { get; set; }
}
