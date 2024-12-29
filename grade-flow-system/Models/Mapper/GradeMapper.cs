using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class GradeMapper
{
    public static GradeResponse Map(Grade grade)
    {
        return new GradeResponse { Id = grade.Id, GradeType = GradeTypeMapper.Map(grade.GradeType), DateAssigned = grade.DateAssigned, Comments = grade.Comments, Student = StudentMapper.Map(grade.Student), Subject = SubjectMapper.Map(grade.Subject)};
    }

    public static Grade Map(GradeRequest gradeRequest)
    {
        return new Grade { GradeTypeId = gradeRequest.GradeTypeId, DateAssigned = gradeRequest.DateAssigned, Comments = gradeRequest.Comments, StudentId = gradeRequest.StudentId, SubjectId = gradeRequest.SubjectId };
    }
}
