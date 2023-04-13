using BlazorMVVM.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorMVVM.Pages;

public partial class UserData
{
    [Inject] public UserDataViewModel UserDataViewModel { get; set; }
    
    protected override async Task OnInitializedAsync()
    {
        await UserDataViewModel.GetUsersAsync();
    }
    
    public void SaveUser()
    {
        UserDataViewModel.SaveUser(UserDataViewModel.User);
    }
}