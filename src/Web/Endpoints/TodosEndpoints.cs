using Application.Todos.Commands;
using Application.Todos.Queries;
using Domain.Entities;
using Mediator;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Endpoints;

public static class TodosEndpoints
{
    public static void MapTodoEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/Todo").WithTags(nameof(Todo));

        group.MapQueries();

        group.MapCommands();
    }

    private static void MapQueries(this IEndpointRouteBuilder group)
    {
        group.MapGet("/", GetAllTodos)
            .WithName("GetAllTodos")
            .WithOpenApi();

        group.MapGet("/{id}", GetTodoById)
            .WithName("GetTodoById")
            .WithOpenApi();
    }


    private static void MapCommands(this IEndpointRouteBuilder group)
    {
        group.MapPut("/{id}", UpdateTodo)
            .WithName("UpdateTodo")
            .WithOpenApi();

        group.MapPost("/", CreateTodo)
            .WithName("CreateTodo")
            .WithOpenApi();

        group.MapDelete("/{id}", DeleteTodo)
            .WithName("DeleteTodo")
            .WithOpenApi();
    }


    #region Queries

    private static async Task<GetTodosDto?> GetAllTodos(ISender sender, [AsParameters] GetAllTodosQuery query)
    {
        return await sender.Send(query);
    }

    private static async Task<Results<Ok<GetTodoDto>, NotFound>> GetTodoById(ISender sender,
        [AsParameters] GetTodoByIdQuery query)
    {
        return await sender.Send(query) is { } model
            ? TypedResults.Ok(model)
            : TypedResults.NotFound();
    }

    #endregion

    #region Commands

    private static async Task<Results<Ok, NotFound>> UpdateTodo(ISender sender, UpdateTodoCommand command)
    {
        int affected = await sender.Send(command);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    private static async Task<Created<CreateTodoCommand>> CreateTodo(ISender sender, CreateTodoCommand command)
    {
        int todoId = await sender.Send(command);

        return TypedResults.Created($"/api/Todo/{todoId}", command);
    }

    private static async Task<Results<Ok, NotFound>> DeleteTodo(ISender sender,
        [AsParameters] DeleteTodoCommand command)
    {
        int affected = await sender.Send(command);

        return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
    }

    #endregion
}
