using MoccaMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoccaMusic.Controllers
{
    class GenerosController
    {
        GenerosModel _generosModel = new GenerosModel();

        public List<GenerosModel> Todos()
        {
            return _generosModel.Todos();
        }

        public GenerosModel Insertar(GenerosModel generoModel)
        {
            return _generosModel.Insertar(generoModel);
        }

        public bool Modificar(GenerosModel generoModel)
        {
            return _generosModel.Modificar(generoModel);
        }

        public bool Eliminar(int idGenero)
        {
            return _generosModel.Eliminar(idGenero);
        }
    }
}