using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HomePetCareCats.App.Dominio;

namespace HomePetCareCats.App.Persistencia
{
    
    public class RepositorioMascota : IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Mascota
        /// </summary>

        private readonly AppContexto _AppContexto;

        /// <summary>
        /// Metodo Constructor Utilizas
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="AppContexto"></param>//
        ///
        public RepositorioMascota()
        {
        }

        public RepositorioMascota(AppContexto AppContexto)
        {
            _AppContexto = AppContexto;
        }

        Mascota IRepositorioMascota.AddMascota(Mascota prmMascota)
        {
            var mascotaAdicionado = _AppContexto.Mascotas.Add(prmMascota);
            _AppContexto.SaveChanges();
            return mascotaAdicionado.Entity;
        }

        IEnumerable<Mascota> IRepositorioMascota.GetAllMascotas()
        {
            return _AppContexto.Mascotas;
        }

        Mascota IRepositorioMascota.GetMascota(int idMascota)
        {
            return _AppContexto.Mascotas.FirstOrDefault(m => m.Id == idMascota);
        }

        Mascota IRepositorioMascota.UpdateMascota (Mascota prmMascota, int idMascota_original)
        {
            var mascotaEncontrada = _AppContexto.Mascotas.FirstOrDefault(m => m.Id == idMascota_original);
            if (mascotaEncontrada != null){
                mascotaEncontrada.Nombre = prmMascota.Nombre;
                mascotaEncontrada.Raza = prmMascota.Raza;
                mascotaEncontrada.Genero = prmMascota.Genero;
                mascotaEncontrada.Edad = prmMascota.Edad;
                _AppContexto.SaveChanges();
            }
            return mascotaEncontrada;

        }
    }
}