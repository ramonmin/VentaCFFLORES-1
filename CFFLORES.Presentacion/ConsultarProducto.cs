using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CFFLORES.WebService.Persistencia;

namespace CFFLORES.Presentacion
{
    public partial class ConsultarProducto : Form
    {
        private DAOProducto daoproducto = new DAOProducto();

        public ConsultarProducto()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para buscar por nombre o tipo, no se debe registrar código de barras.",
                             "Error",
             MessageBoxButtons.OK,
             MessageBoxIcon.Error,
             MessageBoxDefaultButton.Button1);
            MessageBox.Show("El producto <Nombre producto> esta por agotarse.",
             "Adventencia",
             MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);

            MessageBox.Show("El producto <Nombre producto> no cuenta con stock disponible.",
             "Adventencia",
             MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);

            MessageBox.Show("El producto no existe.",
             "Adventencia",
             MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);

            MessageBox.Show("El producto <Nombre producto> está deshabilitado.",
             "Adventencia",
             MessageBoxButtons.OK,
             MessageBoxIcon.Exclamation,
             MessageBoxDefaultButton.Button1);
        }

        private void ConsultarProducto_Load(object sender, EventArgs e)
        {
            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.DataSource = daoproducto.ListarProducto();


        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
