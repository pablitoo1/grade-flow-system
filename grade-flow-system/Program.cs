using grade_flow_system.Configuration;
using grade_flow_system.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var serverVersion = new MySqlServerVersion(new Version(8, 0, 402));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    var filePath = Path.Combine(AppContext.BaseDirectory, "grade-flow-system.xml");
    s.IncludeXmlComments(filePath);
});
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection") ?? "", serverVersion));
builder.Services.AddScoped<GradeService>();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
