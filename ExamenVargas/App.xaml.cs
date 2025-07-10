using ExamenVargas;
using ExamenVargas.Services;
using System.IO;

namespace EJEMPLOPROYECTO
{
    public partial class App : Application
    {
        public static ProyectosDataBase Database;
        public static LogService LogService;

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "proyectos.db3");
            Database = new ProyectosDataBase(dbPath);
            LogService = new LogService("Vargas");

            MainPage = new AppShell();
        }
    }
}