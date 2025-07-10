using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenVargas.Services
{
    public class LogService
    {
        private readonly string _logPath;

        public LogService(string apellido)
        {
            _logPath = Path.Combine(FileSystem.AppDataDirectory, $"Logs_{apellido}.txt");
        }

        public async Task AppendLogAsync(string nombreProyecto)
        {
            string texto = $"Se incluyó el registro [{nombreProyecto}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            await File.AppendAllTextAsync(_logPath, texto);
        }

        public async Task<List<string>> LeerLogsAsync()
        {
            if (!File.Exists(_logPath))
                return new List<string>();

            var lines = await File.ReadAllLinesAsync(_logPath);
            return lines.ToList();
        }
    }
}
