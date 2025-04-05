using TrafficBackendAPI.DatabaseModule;
using TrafficBackendAPI.ReportModule;
using TrafficBackendAPI.UserModule;

var builder = WebApplication.CreateBuilder(args);

#region Default Services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<Program>());
#endregion

#region Modules
var connectionStrings = new List<string>()
{
    builder.Configuration.GetConnectionString("UserDB")!
};

builder.Services.RegisterDatabaseModule(connectionStrings);
builder.Services.RegisterReportModule(builder.Configuration.GetConnectionString("ReportDB")!);
builder.Services.RegisterUserModule();
#endregion

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
