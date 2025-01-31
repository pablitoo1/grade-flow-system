using System.ComponentModel.DataAnnotations;
using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Services;

public class TeacherService(DatabaseContext databaseContext)
{
    public List<TeacherResponse> getAll()
    {
        return databaseContext.Teachers.Select(t => TeacherMapper.Map(t)).ToList();
    }

    public void add(TeacherRequest teacherRequest)
    {
        if (databaseContext.Teachers.Any(t => t.FirstName == teacherRequest.FirstName && t.LastName == teacherRequest.LastName))
        {
            throw new BadRequestException("Teacher already exist");
        }

        try
        {
            databaseContext.Teachers.Add(TeacherMapper.Map(teacherRequest));
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid teacher data: " + ex.Message);
        }
    }

    public void edit(TeacherRequest teacherRequest, int teacherId)
    {
        var teacher = databaseContext.Teachers.SingleOrDefault(t => t.Id == teacherId) ?? throw new NotFoundException("Teacher not found");

        if (databaseContext.Teachers.Any(t => t.FirstName == teacherRequest.FirstName && t.LastName == teacherRequest.LastName))
        {
            throw new BadRequestException("Teacher already exist");
        }

        teacher = TeacherMapper.Map(teacherRequest);

        try
        {
            databaseContext.Teachers.Update(teacher);
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid teacher data: " + ex.Message);
        }
    }

    public void delete(int teacherId)
    {
        var teacher = databaseContext.Teachers.SingleOrDefault(t => t.Id == teacherId) ?? throw new NotFoundException("Teacher not found");

        try
        {
            databaseContext.Teachers.Remove(teacher);
            databaseContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new ConflictException("Teacher is referenced by other data: " + ex.Message);
        }
    }
}
