
using System.Reflection.Metadata;
using System;
using System.Collections.Immutable;
using FluentValidation;
using AspApi.Validators;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using AspApi.Database;
using AspApi;
using FluentValidation.AspNetCore;

//? Dapr
//?  Microservices
//* Odata

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SqliteDb>(options => {
    options.UseSqlite("Data Source=db.sqlite;");
});
builder.Services.AddControllers()
    .AddOData(options => {
        options.Select().Filter().OrderBy().Count().SetMaxTop(null);
        options.AddRouteComponents("odata",ODataEdmModel.Get());
    });
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
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


