using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Models.DTO.Teacher;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;

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
        databaseContext.Teachers.Add(TeacherMapper.Map(teacherRequest));
        databaseContext.SaveChanges();
    }

    public void edit(TeacherRequest teacherRequest, int teacherId)
    {
        var teacher = databaseContext.Teachers.SingleOrDefault(t => t.Id == teacherId) ?? throw new NotFoundException("Teacher not found");

        teacher = TeacherMapper.Map(teacherRequest);

        databaseContext.Teachers.Update(teacher);
        databaseContext.SaveChanges();
    }

    public void delete(int teacherId)
    {
        var teacher = databaseContext.Teachers.SingleOrDefault(t => t.Id == teacherId) ?? throw new NotFoundException("Teacher not found");

        databaseContext.Teachers.Remove(teacher);
        databaseContext.SaveChanges();
    }
}
