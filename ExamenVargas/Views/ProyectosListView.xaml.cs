using ExamenVargas.ViewModels;
namespace ExamenVargas.Views
{
    public partial class ProyectosListView : ContentPage
    {
        ProyectoViewModel viewModel;

        public ProyectosListView()
        {
            InitializeComponent();
            viewModel = new ProyectoViewModel(App.Database, App.LogService);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.CargarProyectos();
        }
    }
}