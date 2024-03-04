using GraphQLDemo.Data;
using GraphQLDemo.Schema.Mutations;
using GraphQLDemo.Schema.Queries;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BookRepository>();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

// Add UseRouting before UseEndpoints
app.UseRouting();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/graphql",
    Path = "/graphql-playground"
});

app.Run();