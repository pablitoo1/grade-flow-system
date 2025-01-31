using System.ComponentModel.DataAnnotations;
using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.StudentsGroup;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Services;

public class StudentsGroupService(DatabaseContext databaseContext)
{
    public List<StudentsGroupResponse> getAll()
    {
        return databaseContext.StudentsGroups.Select(s => StudentsGroupMapper.Map(s)).ToList();
    }

    public void add(StudentsGroupRequest studentsGroupRequest)
    {
        if (databaseContext.StudentsGroups.Any(s => s.Name == studentsGroupRequest.Name))
        {
            throw new BadRequestException("Students group with that name already exist");
        }

        try
        {
            databaseContext.StudentsGroups.Add(StudentsGroupMapper.Map(studentsGroupRequest));
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid students group data: " + ex.Message);
        }
    }

    public void edit(StudentsGroupRequest studentsGroupRequest, int studentsGroupId)
    {
        var studentsGroup = databaseContext.StudentsGroups.SingleOrDefault(s => s.Id == studentsGroupId) ?? throw new NotFoundException("Students group not found");

        if (databaseContext.StudentsGroups.Any(s => s.Name == studentsGroupRequest.Name))
        {
            throw new BadRequestException("Students group with that name already exist");
        }

        studentsGroup = StudentsGroupMapper.Map(studentsGroupRequest);

        try
        {
            databaseContext.StudentsGroups.Update(studentsGroup);
            databaseContext.SaveChanges();
        }
        catch (ValidationException ex)
        {
            throw new BadRequestException("Invalid students group data: " + ex.Message);
        }
    }

    public void delete(int studentsGroupId)
    {
        var studentsGroup = databaseContext.StudentsGroups.SingleOrDefault(s => s.Id == studentsGroupId) ?? throw new NotFoundException("Students group not found");

        try
        {
            databaseContext.StudentsGroups.Remove(studentsGroup);
            databaseContext.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new ConflictException("Students group is referenced by other data: " + ex.Message);
        }
    }
}
