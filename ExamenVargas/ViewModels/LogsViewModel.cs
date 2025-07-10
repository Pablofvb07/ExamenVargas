using ExamenVargas.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVargas.ViewModels
{
    public class LogsViewModel: INotifyPropertyChanged
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
                Logs.Add("Archivo de log no existe");
                return;
            }
            var lines = await File.ReadAllLinesAsync(path);
            if (lines.Length == 0) 
            {
                Logs.Add("El Archivo de Log está vacio.")
            }
        }
    }
}
