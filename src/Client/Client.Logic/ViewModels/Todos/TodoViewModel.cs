namespace Client.Logic.ViewModels.Todos;

public class TodoViewModel
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public DateTimeOffset? DueBy { get; set; }

    public bool IsComplete { get; set; }
}
