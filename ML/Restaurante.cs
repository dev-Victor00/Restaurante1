using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Restaurante
    {
        public int IdRestaurante {  get; set; }
        public string Nombre { get; set; }
        public byte[] Logo { get; set; }
        public int Capacidad { get; set; }
        public List<object> Restaurantes { get; set; }

    }
}
