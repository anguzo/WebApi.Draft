using Client.Logic.Services;
using Client.Logic.ViewModels.Todos;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.Logic.ViewModels;

public partial class FirstUserControlViewModel : ObservableObject
{
    private readonly TodosService _todosService;

    [ObservableProperty] private TodosViewModel? _todosViewModel;


    public FirstUserControlViewModel(TodosService todosService)
    {
        _todosService = todosService;
    }

    [RelayCommand]
    public async Task GetAllTodosAsync()
    {
        TodosViewModel = await _todosService.GetAllTodosAsync();
    }
}
