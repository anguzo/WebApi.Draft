using System.Collections.ObjectModel;
using Client.Logic.OpenAPIs;
using Riok.Mapperly.Abstractions;

namespace Client.Logic.ViewModels.Todos;

public class TodosViewModel
{
    public ObservableCollection<TodoViewModel> Todos { get; set; } = new();
}

[Mapper]
public static partial class TodosViewModelMapper
{
    public static partial TodosViewModel MapToTodosViewModel(this GetTodosDto responseDto);
}
