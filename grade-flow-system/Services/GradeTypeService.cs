using System.ComponentModel.DataAnnotations;
using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Services;

public class GradeTypeService(DatabaseContext databaseContext)
{
    public List<GradeTypeResponse> getAll()
    {
        return databaseContext.GradeTypes.Select(g => GradeTypeMapper.Map(g)).ToList();
    }

    public void add(GradeTypeRequest gradeTypeRequest)
    {
        if (databaseContext.GradeTypes.Any(g => g.Value == gradeTypeRequest.Value))
        {
            throw new BadRequestException("Grade type value already exist");
        }

        try
        {
            databaseContext.GradeTypes.Add(GradeTypeMapper.Map(gradeTypeRequest));
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid grade type data: " + ex.Message);
        }
    }

    public void edit(GradeTypeRequest gradeTypeRequest, int gradeTypeId)
    {
        var gradeType = databaseContext.GradeTypes.SingleOrDefault(g => g.Id == gradeTypeId) ?? throw new NotFoundException("Grade type not found");

        if (databaseContext.GradeTypes.Any(g => g.Value == gradeTypeRequest.Value))
        {
            throw new BadRequestException("Grade type value already exist");
        }

        gradeType = GradeTypeMapper.Map(gradeTypeRequest);

        try
        {
            databaseContext.GradeTypes.Update(gradeType);
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid grade type data: " + ex.Message);
        }
    }

    public void delete(int gradeTypeId) 
    {
        var gradeType = databaseContext.GradeTypes.SingleOrDefault(g => g.Id == gradeTypeId) ?? throw new NotFoundException("Grade type not found");

        try
        {
            databaseContext.GradeTypes.Remove(gradeType);
            databaseContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new ConflictException("Grade type is referenced by other data: " + ex.Message);
        }
    }
}
