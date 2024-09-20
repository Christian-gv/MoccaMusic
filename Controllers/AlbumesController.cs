using MoccaMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoccaMusic.Controllers
{
    public class AlbumesController
    {
        AlbumesModel _albumesModel = new AlbumesModel();

        public List<AlbumesModel> Todos()
        {
            return _albumesModel.Todos();
        }

        public AlbumesModel Insertar(AlbumesModel album)
        {
            return _albumesModel.Insertar(album);
        }

        public bool Eliminar(int idAlbum)
        {
            return _albumesModel.Eliminar(idAlbum);
        }

        public bool Modificar(AlbumesModel album)
        {
            return _albumesModel.Modificar(album);
        }
    }
}
