using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrdersModel
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
