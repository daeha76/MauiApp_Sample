using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels
{
    /***
     * 1. ObservableObject is a class that implements INotifyPropertyChanged
     * 2. EmailAddress vs emailAddress? Password vs password?
     * 3. String vs string?
     */
    public partial class LoginViewModel : ObservableObject
    {
        public bool LoginbuttonEnable => !(string.IsNullOrEmpty(EmailAddress) && string.IsNullOrEmpty(Password));
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LoginbuttonEnable))]
        private string emailAddress;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(LoginbuttonEnable))]
        private string password;
    }
}
