using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;

namespace grade_flow_system.Services;

public class StudentService(DatabaseContext databaseContext)
{
    public List<StudentResponse> getAll()
    {
        return databaseContext.Students.Select(s => StudentMapper.Map(s)).ToList();
    }

    public void add(StudentRequest studentRequest)
    {
        databaseContext.Students.Add(StudentMapper.Map(studentRequest));
        databaseContext.SaveChanges();
    }

    public void edit(StudentRequest studentRequest, int studentId)
    {
        var student = databaseContext.Students.SingleOrDefault(s => s.Id == studentId) ?? throw new NotFoundException("Student not found");

        student = StudentMapper.Map(studentRequest);

        databaseContext.Students.Update(student);
        databaseContext.SaveChanges();
    }

    public void delete(int studentId)
    {
        var student = databaseContext.Students.SingleOrDefault(s => s.Id == studentId) ?? throw new NotFoundException("Student not found");

        databaseContext.Students.Remove(student);
        databaseContext.SaveChanges();
    }
}
