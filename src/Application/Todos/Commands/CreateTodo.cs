namespace Application.Todos.Commands;

public record CreateTodoCommand(string Title, DateOnly DueBy, bool IsComplete) : ICommand<int>;

public class CreateTodoCommandHandler : ICommandHandler<CreateTodoCommand, int>
{
    private readonly IAppDbContext _context;

    public CreateTodoCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<int> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        (string title, DateOnly dueBy, bool isComplete) = command;

        Todo todo = new() { Title = title, DueBy = dueBy, IsComplete = isComplete };


        await _context.Todos.AddAsync(todo, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return todo.Id;
    }
}
