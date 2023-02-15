using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenesServicios
{
    public partial class OrderUpdate : Form
    {
        Controller.MainController ObjController = new Controller.MainController();
        int id;
        public OrderUpdate()
        {
            InitializeComponent();
            cmbCondition.SelectedIndex= 0;
        }

        #region Mover PanelTop
        //Permite mover Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void PanelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            ObjController.UpdateOrder(id, txtClient.Text, dateTimePicker.Value, txtDesc.Text, cmbCondition.Text);
        }

        public void LoadData(int Id, string cliente, string fecha, string descripcion, string estado) {
        id = Id;
        txtClient.Text = cliente;
        dateTimePicker.Text = fecha; 
        txtDesc.Text = descripcion;
            if (estado == "Abierto")
            {
                cmbCondition.SelectedIndex = 0;
            }
            else {
                cmbCondition.SelectedIndex = 1;
            }
        }

        #region icon cerrar
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IconClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
