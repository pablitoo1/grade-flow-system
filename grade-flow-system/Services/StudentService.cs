using System.ComponentModel.DataAnnotations;
using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Services;

public class StudentService(DatabaseContext databaseContext)
{
    public List<StudentResponse> getAll()
    {
        return databaseContext.Students.Select(s => StudentMapper.Map(s)).ToList();
    }

    public void add(StudentRequest studentRequest)
    {
        try
        {
            databaseContext.Students.Add(StudentMapper.Map(studentRequest));
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid student data: " + ex.Message);
        }
    }

    public void edit(StudentRequest studentRequest, int studentId)
    {
        var student = databaseContext.Students.SingleOrDefault(s => s.Id == studentId) ?? throw new NotFoundException("Student not found");

        student = StudentMapper.Map(studentRequest);

        try
        {
            databaseContext.Students.Update(student);
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid student data: " + ex.Message);
        }
    }

    public void delete(int studentId)
    {
        var student = databaseContext.Students.SingleOrDefault(s => s.Id == studentId) ?? throw new NotFoundException("Student not found");

        try
        {
            databaseContext.Students.Remove(student);
            databaseContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new ConflictException("Student is referenced by other data: " + ex.Message);
        }
    }
}
