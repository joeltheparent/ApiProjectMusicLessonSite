var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

//app.MapGet("/courses", () =>
//{
//    return "Reading all the courses";
//});

//app.MapGet("/courses/{id}", (int id) =>
//{
//    return $"Reading course with ID: {id}";
//});

//app.MapPost("/courses", () =>
//{
//    return "Creating a course";
//});

//app.MapPut("/courses/{id}", (int id) =>
//{
//    return $"Uptdating course with ID : {id}";
//});

//app.MapDelete("/courses/{id}", (int id) =>
//{
//    return $"Deleting course with ID: {id}";
//});



app.UseAuthorization();

app.MapControllers();

app.Run();
