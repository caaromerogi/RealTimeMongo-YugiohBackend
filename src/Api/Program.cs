using Api.Extensions;
using Mongo.DatabaseHelper;
using Mongo.Streams;
using SignalRHub.Hub;
using SignalRHub.Sender;
using UseCases.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Secrets secrets = builder.Configuration.GetSection(nameof(Secrets)).Get<Secrets>()!;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.RegisterServices();
builder.Services.RegisterMongoContext(secrets.MongoConnectionString, secrets.DatabaseName);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", c =>
    {
        c.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHub<NotificationReceiverHub>("/messagehub");

var stream = app.Services.GetRequiredService<IChangeStreamMongo>();
var observer = app.Services.GetRequiredService<INotificationSender>();

app.UseHttpsRedirection();

stream.SubscribeAsync(observer);

app.UseCors("Cors");

app.UseAuthorization();

app.MapControllers();
//(await notifier.ConnectToStream()).Subscribe();


app.Run();
