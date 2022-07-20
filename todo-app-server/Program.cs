using todo_app_server.Data;

var builder = WebApplication.CreateBuilder(args);

// (Allow CORS) Allow Our React-Client to Interact with our API
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            .WithOrigins("http://localhost:3000");
        });
});

// Add services to the container.
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

app.UseCors("CORSPolicy");

// End-Points
// (The "Controllers" in the MVC Architectural Pattern)

// Get All Todos
app.MapGet("/get-all-todos", async () => await EntriesRepository.GetAllTodosAsync());

// Get Todo By ID
app.MapGet("/get-todo-by-id/{id}", async (int id) =>
{
    Entry todoToReturn = await EntriesRepository.GetTodoByIDAsync(id);

    // if the id is in the db
    if (todoToReturn != null)
    {
        return Results.Ok(todoToReturn);
    }
    // if the id isn't in the db
    else
    {
        return Results.BadRequest();
    }
});

// Create Todo
app.MapPost("/create-todo", async (Entry todoToCreate) =>
{
    bool createIsSuccessful = await EntriesRepository.CreateTodoAsync(todoToCreate);

    if (createIsSuccessful)
    {
        return Results.Ok("create is successful");
    }
    else
    {
        return Results.BadRequest();
    }
});

// Update Todo
app.MapPut("/update-todo", async (Entry todoToUpdate) =>
{
    bool updateIsSuccessful = await EntriesRepository.UpdateTodoAsync(todoToUpdate);

    if (updateIsSuccessful)
    {
        return Results.Ok("update is successful");
    }
    else
    {
        return Results.BadRequest();
    }
});

// Delete Todo By ID
app.MapDelete("/delete-todo-by-id/{id}", async (int id) =>
{
    bool deleteIsSuccessful = await EntriesRepository.DeleteTodoByIDAsync(id);

    if (deleteIsSuccessful)
    {
        return Results.Ok("delete is successful");
    }
    else
    {
        return Results.BadRequest();
    }
});


app.Run();