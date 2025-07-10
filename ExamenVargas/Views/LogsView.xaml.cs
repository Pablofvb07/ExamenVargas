using ExamenVargas.ViewModels;
namespace ExamenVargas.Views;

public partial class LogsView : ContentPage
{
	public LogsView()
	{
		InitializeComponent();
		BindingContext = new LogsViewModel(App.LogService);
	}
}