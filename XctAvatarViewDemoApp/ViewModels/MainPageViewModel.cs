using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using XctAvatarViewDemoApp.Models;

namespace XctAvatarViewDemoApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        private ObservableRangeCollection<UserInfo> _users;
        public ObservableRangeCollection<UserInfo> Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public ICommand LoadUsersInfoCommand { get; set; }

        public MainPageViewModel()
        {
            _httpClient = new HttpClient();

            LoadUsersInfoCommand = new AsyncCommand(LoadUsersInfoAsync);
            Users = new ObservableRangeCollection<UserInfo>();
        }

        private async Task LoadUsersInfoAsync()
        {
            try
            {
                if (Users.Count > 0)
                    return;

                var result = await _httpClient.GetStringAsync("https://randomuser.me/api/?results=20");
                var data = ApiResponse.FromJson(result);
                Users.AddRange(data.Users);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error occured while fetching user information: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
