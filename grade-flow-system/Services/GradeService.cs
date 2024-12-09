using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO;
using grade_flow_system.Models.Mapper;
using Microsoft.EntityFrameworkCore;

namespace grade_flow_system.Services;

public class GradeService(DatabaseContext databaseContext)
{
    public List<GradeResponse> getAll()
    {
        return databaseContext.Grades.Select(g => GradeMapper.Map(g)).ToList();
    }

    public void add(GradeRequest gradeRequest)
    {
        databaseContext.Grades.Add(GradeMapper.Map(gradeRequest));
        databaseContext.SaveChanges();
    }
}
