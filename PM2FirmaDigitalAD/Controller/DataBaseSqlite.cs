using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace PM2FirmaDigitalAD.Controller
{
    public class DataBaseSqlite
    {
        SQLiteAsyncConnection db;

        public DataBaseSqlite(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Models.UsuarioFirma>().Wait();
        }

        public Task<int> GuardarUsuario(Models.UsuarioFirma usuario)
        {
            return db.InsertAsync(usuario);
        }
        
        public Task<List<Models.UsuarioFirma>> ObtenerListadoUsuarios()
        {
            return db.Table<Models.UsuarioFirma>().ToListAsync();
        }
    }
}
