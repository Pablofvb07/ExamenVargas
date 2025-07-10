
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ExamenVargas.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Storage;
using System.IO;

namespace EJEMPLOPROYECTO.ViewModels
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Logs { get; set; } = new ObservableCollection<string>();

        private readonly LogService _logService;

        public LogsViewModel(LogService logService)
        {
            _logService = logService;
            CargarLogs();
        }

        private async void CargarLogs()
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "Logs_Vargas.txt");

            if (!File.Exists(path))
            {
                Logs.Add("Archivo de log no existe.");
                return;
            }

            var lines = await File.ReadAllLinesAsync(path);
            if (lines.Length == 0)
            {
                Logs.Add("El archivo de log está vacío.");
                return;
            }

            Logs.Clear();
            foreach (var log in lines)
            {
                Logs.Add(log);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}