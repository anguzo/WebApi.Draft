using Client.Logic.OpenAPIs;
using Client.Logic.ViewModels.Todos;

namespace Client.Logic.Services;

public class TodosService
{
    private readonly IApiClient _apiClient;

    public TodosService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<TodosViewModel> GetAllTodosAsync()
    {
        GetTodosDto? responseDto = await _apiClient.GetAllTodosAsync();

        TodosViewModel todosViewModel = responseDto.MapToTodosViewModel();

        return todosViewModel;
    }
}
