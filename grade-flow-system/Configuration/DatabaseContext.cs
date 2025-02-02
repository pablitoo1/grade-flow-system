﻿using grade_flow_system.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Configuration;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    public required DbSet<Grade> Grades { get; init; } // init bo ma byc utworzona tylko raz
    public required DbSet<GradeType> GradeTypes { get; init; }
    public required DbSet<Student> Students { get; init; }
    public required DbSet<Subject> Subjects { get; init; }
    public required DbSet<Teacher> Teachers { get; init; }
    public required DbSet<StudentsGroup> StudentsGroups { get; init; }
}
