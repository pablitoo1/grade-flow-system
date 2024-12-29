using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.DTO.StudentsGroup;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class StudentsGroupMapper
{
    public static StudentsGroupResponse Map(StudentsGroup studentsGroup)
    {
        return new StudentsGroupResponse { Id = studentsGroup.Id, Name = studentsGroup.Name, Students = studentsGroup.Students.Select(StudentMapper.Map).ToList() };
    }

    public static StudentsGroup Map(StudentsGroupRequest studentsGroupRequest)
    {
        return new StudentsGroup { Name = studentsGroupRequest.Name };
    }
}
