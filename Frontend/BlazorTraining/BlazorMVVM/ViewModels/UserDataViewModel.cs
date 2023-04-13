using BlazorMVVM.DTOs;
using BlazorMVVM.Models;

namespace BlazorMVVM.ViewModels;

public class UserDataViewModel
{
    private readonly IUserModel _userModel;
    public List<User> Users { get; private set; }
    public User User { get; private set; } = new();
    
    public UserDataViewModel(IUserModel userModel)
    {
        _userModel = userModel;
    }
    
    public async Task GetUsersAsync()
    {
        Users = await _userModel.GetUsersAsync();
    }
    
    public void SetUser(User user)
    {
        User = user;
    }
    
    public void SaveUser(User user)
    {
        if (_isAdd)
        {
            //TODO Validation
            Users.Add(user);
        }
        else
        {
            var loUser = Users.FirstOrDefault(x => x.Id == user.Id);
            loUser = user;
        }
        _isAdd = false;
    }
    
    private bool _isAdd = false;
    public bool IsAdd
    {
        get => _isAdd;
    }
    
    public void AddUser()
    {
        User = new User();
        _isAdd = true;
    }
    
    public void DeleteUser(User user)
    {
        //TODO validation or confirmation
        var loUser = Users.FirstOrDefault(x => x.Id == user.Id);
        Users.Remove(loUser);
    }
    
}