
using Microsoft.EntityFrameworkCore;
using AspApi.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddDbContext<SqliteDb>(options => {
    options.UseSqlite("Data Source=db.sqlite;");
});
builder.Services.AddSwaggerGen();



// ! build
var app = builder.Build();

app.MapControllers();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}
// ! run
app.Run();

