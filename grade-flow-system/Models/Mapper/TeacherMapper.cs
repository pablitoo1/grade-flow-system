using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class TeacherMapper
{
    public static TeacherResponse Map(Teacher teacher)
    {
        return new TeacherResponse { Id = teacher.Id, FirstName = teacher.FirstName, LastName = teacher.LastName, Email = teacher.Email, Subjects = SubjectMapper.Map(teacher.Subjects)};
    }

    public static Teacher Map(TeacherRequest teacherRequest)
    {
        return new Teacher { FirstName = teacherRequest.FirstName, LastName = teacherRequest.LastName, Email = teacherRequest.Email };
    }
}
