using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataIssue;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(o =>
    {
        o.EnableQueryFeatures();

        var builder = new ODataConventionModelBuilder();
        builder.EntitySet<Weather>(nameof(Weather));
        builder.EntitySet<City>(nameof(City));
        o.AddRouteComponents(builder.GetEdmModel());
    }
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
