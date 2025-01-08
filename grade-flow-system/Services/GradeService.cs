using grade_flow_system.Configuration;
using grade_flow_system.Models.DTO.Grade;
using grade_flow_system.Models.DTO.GradeType;
using grade_flow_system.Models.Mapper;
using HttpExceptions.Exceptions;

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

    public void edit(GradeRequest gradeRequest, int id)
    {
        var grade = databaseContext.Grades.SingleOrDefault(g => g.Id == id) ?? throw new NotFoundException("Grade not found");

        grade = GradeMapper.Map(gradeRequest);

        databaseContext.Grades.Update(grade);
        databaseContext.SaveChanges();
    }

    public void delete(int id)
    {
        var grade = databaseContext.Grades.SingleOrDefault(g => g.Id == id) ?? throw new NotFoundException("Grade not found");

        databaseContext.Grades.Remove(grade);
        databaseContext.SaveChanges();
    }
}
