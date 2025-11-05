using ENTITY;
using System;
using System.Collections.Generic;
using DAL;
using ENTITY;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicioGraficas
    {
        GraficasRepository graficasRepository;
        public ServicioGraficas()
        {
            graficasRepository = new GraficasRepository(Utils.ARC_GRAFICOS);
        }
        public ReadOnlyCollection<Main> MostrarTodos()
        {
            var lista = graficasRepository.MostrarTodos();
            if (lista == null)
            {
                return new ReadOnlyCollection<Main>(new List<Main>());
            }
            return new ReadOnlyCollection<Main>(lista);
        }
        public void GuardarDatos(Main datos)
        {
            try
            {
                if (datos == null)
                {
                    throw new ArgumentNullException("Los datos que se intentó guardar es nulo");
                }
                graficasRepository.Guardar(datos);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR..."+e);
                return;
            }
        }

    }
}
