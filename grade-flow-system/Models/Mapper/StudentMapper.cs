using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class StudentMapper
{
    public static StudentResponse Map(Student student)
    {
        return new StudentResponse { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName, Email = student.Email, Grades = GradeMapper.Map(student.Grades) };
    }

    public static Student Map(StudentRequest studentRequest)
    {
        return new Student { FirstName = studentRequest.FirstName, LastName = studentRequest.LastName, Email = studentRequest.Email };
    }
}
