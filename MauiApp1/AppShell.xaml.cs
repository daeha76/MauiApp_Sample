using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        this.BindingContext = new MainViewModel();
    }
}
