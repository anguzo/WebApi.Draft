namespace Application.Todos.Queries;

public record GetAllTodosQuery : IQuery<GetTodosDto?>;

public class GetAllTodosQueryHandler : IQueryHandler<GetAllTodosQuery, GetTodosDto?>
{
    private readonly IAppDbContext _context;

    public GetAllTodosQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<GetTodosDto?> Handle(GetAllTodosQuery query, CancellationToken cancellationToken)
    {
        List<GetTodoDto> todos = await _context.Todos.TagWith("GetAllTodos").AsNoTracking().ProjectToTodoDto()
            .ToListAsync(cancellationToken);
        return new GetTodosDto { Todos = todos };
    }
}
