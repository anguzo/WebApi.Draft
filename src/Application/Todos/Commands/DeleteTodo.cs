namespace Application.Todos.Commands;

public record DeleteTodoCommand(int Id) : ICommand<int>;

public class DeleteTodoCommandHandler : ICommandHandler<DeleteTodoCommand, int>
{
    private readonly IAppDbContext _context;

    public DeleteTodoCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<int> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
        int id = command.Id;

        int affected = await _context.Todos
            .Where(model => model.Id == id)
            .ExecuteDeleteAsync(cancellationToken);


        return affected;
    }
}
