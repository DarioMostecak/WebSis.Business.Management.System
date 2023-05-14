using WebSis.Business.Management.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

var app = builder.Build();

app.RegisterPiplineComponents(typeof(Program));

app.Run();
