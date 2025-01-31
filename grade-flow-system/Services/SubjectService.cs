using System.ComponentModel.DataAnnotations;
using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.DTO.Student;
using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Models.Entity;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Services;

public class SubjectService(DatabaseContext databaseContext)
{
    public List<SubjectResponse> getAll()
    {
        return databaseContext.Subjects.Select(s => SubjectMapper.Map(s)).ToList();
    }

    public void add(SubjectRequest subjectRequest)
    {
        if (databaseContext.Subjects.Any(s => s.Name == subjectRequest.Name))
        {
            throw new BadRequestException("Subject with that name already exist");
        }

        try
        {
            databaseContext.Subjects.Add(SubjectMapper.Map(subjectRequest));
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid subject data: " + ex.Message);
        }
    }

    public void edit(SubjectRequest subjectRequest, int subjectId)
    {
        var subject = databaseContext.Subjects.SingleOrDefault(s => s.Id == subjectId) ?? throw new NotFoundException("Subject not found");

        subject = SubjectMapper.Map(subjectRequest);

        try
        {
            databaseContext.Subjects.Update(subject);
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid subject data: " + ex.Message);
        }
    }

    public void delete(int subjectId)
    {
        var subject = databaseContext.Subjects.SingleOrDefault(s => s.Id == subjectId) ?? throw new NotFoundException("Subject not found");

        try
        {
            databaseContext.Subjects.Remove(subject);
            databaseContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new ConflictException("Subject is referenced by other data: " + ex.Message);
        }
    }
}
