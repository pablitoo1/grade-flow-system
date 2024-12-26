using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class GradeMapper
{
    public static GradeResponse Map(Grade grade)
    {
        return new GradeResponse { id = grade.Id, gradeType = grade.GradeType, dateAssigned = grade.DateAssigned, comments = grade.Comments, student = grade.Student, subject = grade.Subject};
    }

    public static Grade Map(GradeRequest gradeRequest)
    {
        return new Grade { GradeType = gradeRequest.gradeType, DateAssigned = gradeRequest.dateAssigned, Comments = gradeRequest.comments, Student = gradeRequest.student, Subject = gradeRequest.subject };
    }
}
