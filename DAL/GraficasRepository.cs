using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DAL
{
    public class GraficasRepository : BaseRepository<Main>
    {
        public GraficasRepository(string nombreArchivo) : base(nombreArchivo)
        {
        }
        public override IList<Main> MostrarTodos()
        {
            try
            {
                var lista = new List<Main>();

                using (StreamReader lector = new StreamReader(ruta))
                {
                    while (!lector.EndOfStream)
                    {
                        var linea = lector.ReadLine();
                        if (!string.IsNullOrWhiteSpace(linea))
                        {
                            lista.Add(Mappear(linea));
                        }
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo: " + ex.Message);
                return new List<Main>();
            }
        }
        private Main Mappear(string linea)
        {
            Main Grafica = new Main();

            var aux = linea.Split(';');
            Grafica.temp = double.Parse(aux[0]);
            Grafica.humidity = double.Parse(aux[1]);

            return Grafica;
        }

        public override Main ObtenerPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
