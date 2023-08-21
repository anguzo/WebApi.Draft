namespace Application.Todos.Queries;

public class GetTodoDto
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public DateOnly? DueBy { get; set; }

    public bool IsComplete { get; set; }
}

[Mapper]
public static partial class TodoDtoMapper
{
    [MapperIgnoreSource(nameof(Todo.DomainEvents))]
    public static partial GetTodoDto MapToTodoDto(this Todo todoItem);

    public static partial IQueryable<GetTodoDto> ProjectToTodoDto(this IQueryable<Todo> q);
}
