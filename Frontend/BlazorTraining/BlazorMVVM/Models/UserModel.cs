using System.Net.Http.Json;
using BlazorMVVM.DTOs;

namespace BlazorMVVM.Models;

public interface IUserModel
{
    Task<List<User>> GetUsersAsync();
}

public class UserDummyModel : IUserModel
{
    public Task<List<User>> GetUsersAsync()
    {
        var loRtn = new List<User>();

        for (int i = 0; i < 3; i++)
        {
            loRtn.Add(new User
            {
                Id = i,
                Username = $"User{i}",
                Email = $"user{i}@gmail.com",
                Password = "1234"
            });
        }

        return Task.FromResult(loRtn);
    }
}

public class UserApiModel : IUserModel
{
    private readonly HttpClient _httpClient;

    public UserApiModel(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<User>>("sample-data/user.json");
    }
}
