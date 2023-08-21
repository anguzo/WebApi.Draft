namespace Application.Todos.Commands;

public record UpdateTodoCommand(int Id, string Title, DateOnly DueBy, bool IsComplete) : ICommand<int>;

public class UpdateTodoCommandHandler : ICommandHandler<UpdateTodoCommand, int>
{
    private readonly IAppDbContext _context;

    public UpdateTodoCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<int> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
    {
        (int id, string title, DateOnly dueBy, bool isComplete) = command;

        int affected = await _context.Todos
            .Where(model => model.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Title, title)
                .SetProperty(m => m.DueBy, dueBy)
                .SetProperty(m => m.IsComplete, isComplete), cancellationToken);


        return affected;
    }
}
