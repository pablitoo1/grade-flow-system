using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;

namespace grade_flow_system.Services;

public class GradeService(DatabaseContext databaseContext)
{
    //public List<GradeResponse> getAll()
    //{
    //    return databaseContext.Grades.Select(g => GradeMapper.Map(g)).ToList();
    //}

    //public void add(GradeRequest gradeRequest)
    //{
    //    if (databaseContext.Grades.Any(g => g.value == gradeRequest.value)) {
    //        throw new BadRequestException("Grade already exist");
    //    }
    //    databaseContext.Grades.Add(GradeMapper.Map(gradeRequest));
    //    databaseContext.SaveChanges();
    //}
}
