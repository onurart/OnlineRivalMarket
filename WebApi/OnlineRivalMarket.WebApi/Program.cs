    using Microsoft.EntityFrameworkCore;
using OnlineRivalMarket.Persistance.Context;
using OnlineRivalMarket.WebApi;
using OnlineRivalMarket.WebApi.Configurations;
using System.Text.Json.Serialization;
;
var builder = WebApplication.CreateBuilder(args);
builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter("dd-MM-yyyy HH:mm"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
using (var context = new AppDbContext()) { context.Database.Migrate(); }
app.Run();