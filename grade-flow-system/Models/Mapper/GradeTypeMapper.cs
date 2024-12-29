using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.Entity;

namespace grade_flow_system.Models.Mapper;

public class GradeTypeMapper
{
    public static GradeTypeResponse Map(GradeType gradeType)
    {
        return new GradeTypeResponse { Id = gradeType.Id, Value = gradeType.Value, Description = gradeType.Description };
    }

    public static GradeType Map(GradeTypeRequest gradeTypeRequest)
    {
        return new GradeType { Value = gradeTypeRequest.Value, Description = gradeTypeRequest.Description };
    }
}
