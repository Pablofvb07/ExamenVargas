using ExamenVargas.ViewModels;
namespace ExamenVargas.Views
{
    public partial class ProyectoFormView : ContentPage
    {
        public ProyectoFormView()
        {
            InitializeComponent();
            BindingContext = new ProyectosViewsModels(App.Database, App.LogService);
        }
    }
}