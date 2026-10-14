using imc.Maui.ViewModels;

namespace imc.Maui.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainViewModel();
	}


}