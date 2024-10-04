using Aquilo.MAUI.ViewModels;

namespace Aquilo.MAUI.Views;

public partial class StartView : ContentPage
{
	StartViewModel StartViewModel;
	public StartView(StartViewModel startViewModel)
	{
		BindingContext = StartViewModel = startViewModel;
		InitializeComponent();
	}
}