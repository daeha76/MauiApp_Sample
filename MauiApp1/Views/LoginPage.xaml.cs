using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        this.BindingContext = new LoginViewModel();
    }
}