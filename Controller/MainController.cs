using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.service;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Controller
{
    public class MainController
    {

        //Mostrar ordenes
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

        public void InsertOrder(string NomCliente, DateTime fecha, string descripcion, string status ) {

            try
            {
                using (Model.service.servicioEntities db = new Model.service.servicioEntities())
                {
                    ordenes ObjOrdenes = new ordenes();
                    
                    ObjOrdenes.nombre_cliente = NomCliente;
                    ObjOrdenes.fecha_creacion = fecha;
                    ObjOrdenes.descripcion = descripcion;
                    ObjOrdenes.estado = status;

                    db.ordenes.Add( ObjOrdenes );
                    db.SaveChanges();

                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Órden creada.", "Nueva órden de servicio", buttons);
                }
               
            }catch(Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Ocurrió un error al intentar crear la órden. " +
                    "Consulte al administrador.", "Nueva órden de servicio", buttons);
            }
        }


        public void UpdateOrder(int id, string nombre, DateTime fecha, string descripcion, string status) {
            try
            {
                using (Model.service.servicioEntities db = new Model.service.servicioEntities())
                {
                    ordenes table = null;

                    table = db.ordenes.Find(id);
                    table.nombre_cliente = nombre;
                    table.fecha_creacion = fecha;
                    table.descripcion = descripcion;
                    table.estado = status;
                    db.SaveChanges();

                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show("Modificación en órden realizada.", "Modificar órden de servicio.", buttons);
                }

            }
            catch (Exception ex)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Ocurrió un error al intentar modificar la órden. " +
                    "Consulte al administrador.", "Modificar órden de servicio", buttons);
            }

           
        }
    }
}
