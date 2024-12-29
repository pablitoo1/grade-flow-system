using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.DTO.Subject;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class SubjectMapper
{
    public static SubjectResponse Map(Subject subject)
    {
        return new SubjectResponse { Id = subject.Id, Name = subject.Name, Description = subject.Description, Grades = subject.Grades.Select(GradeMapper.Map).ToList() };
    }

    public static Subject Map(SubjectRequest subjectRequest)
    {
        return new Subject { Name = subjectRequest.Name, Description = subjectRequest.Description };
    }
}
