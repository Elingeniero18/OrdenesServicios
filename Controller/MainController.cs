using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MainController
    {
        public IEnumerable<Model.OrdersModel> GetOrders() {

            using (Model.service.servicioEntities db =  new Model.service.servicioEntities()) 
            {
                 IEnumerable < Model.OrdersModel > list = (from i in db.ordenes
                                                  select new Model.OrdersModel
                                                  { 
                                                  Id= i.id,
                                                  NombreCliente= i.nombre_cliente,
                                                  FechaCreacion= i.fecha_creacion,  
                                                  Descripcion= i.descripcion,
                                                  Estado = i.estado
                                                  }).ToList();
                return list;
            }

        }
    }
}
