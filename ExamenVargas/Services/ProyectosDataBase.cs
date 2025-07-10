using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenVargas.Models;
using SQLite;
namespace ExamenVargas.Services
{
    public class ProyectosDataBase
    {
        private readonly SQLiteAsyncConnection _database;
        public ProyectosDataBase(string dbPath) 
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Proyectos>().Wait();
        }
        public Task<int> AddProyectosAsync(Proyectos proyectos) 
        {
            return _database.InsertAsync(proyectos);
        }
        public Task<List<Proyectos>> GetProyectosAsync() 
        {
            return _database.Table<Proyectos>().ToListAsync();
        }
    }
}
