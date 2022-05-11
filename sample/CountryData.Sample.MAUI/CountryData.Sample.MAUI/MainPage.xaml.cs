using CountryData.Sample.MAUI.ViewModels;

namespace CountryData.Sample.MAUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(MainViewModel mainViewModel)
	{
		InitializeComponent();
		BindingContext = mainViewModel;
	}

	//private void OnCounterClicked(object sender, EventArgs e)
	//{
	//	count++;
	//	CounterLabel.Text = $"Current count: {count}";

	//	SemanticScreenReader.Announce(CounterLabel.Text);
	//}
}

