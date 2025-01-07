﻿using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;

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
        databaseContext.GradeTypes.Add(GradeTypeMapper.Map(gradeTypeRequest));
        databaseContext.SaveChanges();
    }

    public void edit(GradeTypeRequest gradeTypeRequest, int id)
    {
        var gradeType = databaseContext.GradeTypes.SingleOrDefault(g => g.Id == id) ?? throw new NotFoundException("Grade type not found");

        if (databaseContext.GradeTypes.Any(g => g.Value == gradeTypeRequest.Value))
        {
            throw new BadRequestException("Grade type value already exist");
        }

        gradeType.Description = gradeTypeRequest.Description;
        gradeType.Value = gradeTypeRequest.Value;

        databaseContext.GradeTypes.Update(gradeType);
        databaseContext.SaveChanges();
    }

    public void delete(int id) 
    {
        var gradeType = databaseContext.GradeTypes.SingleOrDefault(g => g.Id == id) ?? throw new NotFoundException("Grade type not found");

        databaseContext.GradeTypes.Remove(gradeType);
        databaseContext.SaveChanges();
    }
}