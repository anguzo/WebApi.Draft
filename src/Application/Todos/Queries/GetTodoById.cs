namespace Application.Todos.Queries;

public record GetTodoByIdQuery(int Id) : IQuery<GetTodoDto?>;

public class GetTodoByIdQueryHandler : IQueryHandler<GetTodoByIdQuery, GetTodoDto?>
{
    private readonly IAppDbContext _context;

    public GetTodoByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<GetTodoDto?> Handle(GetTodoByIdQuery query, CancellationToken cancellationToken)
    {
        int id = query.Id;
        return await _context.Todos.TagWith("GetTodoById").AsNoTracking().ProjectToTodoDto()
            .SingleOrDefaultAsync(m => m.Id == id, cancellationToken);
    }
}
