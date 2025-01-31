using System.ComponentModel.DataAnnotations;
using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Services;

public class GradeService(DatabaseContext databaseContext)
{
    public List<GradeResponse> getAll()
    {
        return databaseContext.Grades.Select(g => GradeMapper.Map(g)).ToList();
    }

    public void add(GradeRequest gradeRequest)
    {
        try
        {
            databaseContext.Grades.Add(GradeMapper.Map(gradeRequest));
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid grade data: " + ex.Message);
        }
    }

    public void edit(GradeRequest gradeRequest, int gradeId)
    {
        var grade = databaseContext.Grades.SingleOrDefault(g => g.Id == gradeId) ?? throw new NotFoundException("Grade not found");

        grade = GradeMapper.Map(gradeRequest);

        try
        {
            databaseContext.Grades.Update(grade);
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid grade data: " + ex.Message);
        }
    }

    public void delete(int gradeId)
    {
        var grade = databaseContext.Grades.SingleOrDefault(g => g.Id == gradeId) ?? throw new NotFoundException("Grade not found");

        try
        {
            databaseContext.Grades.Remove(grade);
            databaseContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new ConflictException("Grade is referenced by other data: " + ex.Message);
        }
    }
}
