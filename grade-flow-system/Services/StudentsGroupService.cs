using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.StudentsGroup;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;

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
        databaseContext.StudentsGroups.Add(StudentsGroupMapper.Map(studentsGroupRequest));
        databaseContext.SaveChanges();
    }

    public void edit(StudentsGroupRequest studentsGroupRequest, int studentsGroupId)
    {
        var studentsGroup = databaseContext.StudentsGroups.SingleOrDefault(s => s.Id == studentsGroupId) ?? throw new NotFoundException("Students group not found");

        studentsGroup = StudentsGroupMapper.Map(studentsGroupRequest);

        databaseContext.StudentsGroups.Update(studentsGroup);
        databaseContext.SaveChanges();
    }

    public void delete(int studentsGroupId)
    {
        var studentsGroup = databaseContext.StudentsGroups.SingleOrDefault(s => s.Id == studentsGroupId) ?? throw new NotFoundException("Students group not found");

        databaseContext.StudentsGroups.Remove(studentsGroup);
        databaseContext.SaveChanges();
    }
}
