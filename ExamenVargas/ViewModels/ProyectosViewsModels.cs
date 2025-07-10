using ExamenVargas.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ExamenVargas.Services;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace ExamenVargas.ViewModels
{
    public class ProyectoViewModel : INotifyPropertyChanged
    {
        private string _nombreProyecto;
        private string _responsable;
        private decimal _progreso;
        private int _duracionDias;

        public string NombreProyecto
        {
            get => _nombreProyecto;
            set { _nombreProyecto = value; OnPropertyChanged(); }
        }

        public string Responsable
        {
            get => _responsable;
            set { _responsable = value; OnPropertyChanged(); }
        }

        public decimal Progreso
        {
            get => _progreso;
            set { _progreso = value; OnPropertyChanged(); }
        }

        public int DuracionDias
        {
            get => _duracionDias;
            set { _duracionDias = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Proyectos> Proyectos { get; set; }

        public ICommand GuardarCommand { get; }

        private readonly ProyectosDataBase _database;
        private readonly LogService _logService;

        public ProyectoViewModel(ProyectosDataBase database, LogService logService)
        {
            _database = database;
            _logService = logService;

            Proyectos = new ObservableCollection<Proyectos>();
            GuardarCommand = new Command(async () => await GuardarProyecto());

            CargarProyectos();
        }

        public async void CargarProyectos()
        {
            var proyectos = await _database.GetProyectosAsync();
            Proyectos.Clear();

            if (proyectos.Count == 0)
            {
                Proyectos.Add(new Proyectos { NombreProyecto = "No hay proyectos guardados aún." });
            }
            else
            {
                foreach (var p in proyectos)
                {
                    Proyectos.Add(p);
                }
            }
        }


        private async Task GuardarProyecto()
        {
            await Application.Current.MainPage.DisplayAlert("DEBUG", "Guardando...", "OK");

            if (!ValidarProyecto(out string error))
            {
                await Application.Current.MainPage.DisplayAlert("Error", error, "OK");
                return;
            }

            var proyecto = new Proyectos
            {
                NombreProyecto = NombreProyecto,
                Responsable = Responsable,
                Progreso = Progreso,
                DuracionDias = DuracionDias
            };

            await _database.AddProyectosAsync(proyecto);
            await _logService.AppendLogAsync(proyecto.NombreProyecto);
            Proyectos.Add(proyecto);

            NombreProyecto = string.Empty;
            Responsable = string.Empty;
            Progreso = 0;
            DuracionDias = 0;
        }

        private bool ValidarProyecto(out string errorMensaje)
        {
            if (Progreso > 50 && DuracionDias < 365)
            {
                errorMensaje = "No se puede guardar un proyecto con progreso mayor al 50% y duración menor a un año.";
                return false;
            }
            errorMensaje = null;
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}