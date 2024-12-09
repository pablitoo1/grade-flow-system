using grade_flow_system.Models.DTO;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class GradeMapper
{
    public static GradeResponse Map(Grade grade)
    {
        return new GradeResponse { Id = grade.Id, value = grade.value };
    }

    public static Grade Map(GradeRequest gradeRequest)
    {
        return new Grade {value = gradeRequest.value };
    }
}
