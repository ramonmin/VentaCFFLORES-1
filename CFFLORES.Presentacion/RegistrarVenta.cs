using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace CFFLORES.Presentacion
{
    public partial class RegistrarVenta : Form
    {
        public RegistrarVenta()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConsultarProducto frmProducto = new ConsultarProducto();
            frmProducto.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Add(this.tabPage2);

           tabControl1.SelectedIndex = 1;
        }

        private void button9_Click(object sender, EventArgs e)
        {


            int count = 0;

            for (int i = 0; i <= dgvVenta.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dgvVenta.Rows[i].Cells["Column1"].Value) == true)
                {
                    ++count;
                }
            }


            if (count == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos una Venta",
                "Adventencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            this.tabControl1.TabPages.Add(this.tabPage2);

            tabControl1.SelectedIndex = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Se realizó la Venta.",
            "EXITO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1);
            tabControl1.SelectedIndex = 0;
            this.tabControl1.TabPages.Remove(this.tabPage2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está Seguro que desea cancelar la Venta?",
            "Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.tabControl1.TabPages.Remove(this.tabPage2);
                tabControl1.SelectedIndex = 0;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            int count = 0;
            for (int i = 0; i <= dgvVenta.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dgvVenta.Rows[i].Cells["Column1"].Value) == true)
                {
                    ++count;

                }
            }


            if (count == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos una Venta",
                "Adventencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }
            

            DialogResult result = MessageBox.Show("¿Está Seguro que desea Anular la Venta?",
            "Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {

                for (int i = 0; i <= dgvVenta.RowCount - 1; i++)
                {
                    if (Convert.ToBoolean(dgvVenta.Rows[i].Cells["Column1"].Value) == true)
                    {
                        string id = dgvVenta.Rows[i].Cells["IdVenta"].Value.ToString();
                        Modificar(id,"0");

                    }
                }
            }
        }

        private void Modificar(string idcliente, string estado)
        {
            string id = idcliente;
            string st = estado;
            string postdata = "{\"IdVenta\":\"" + id + "\",\"Estado\":\"" + st + "\"}";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            string URLAuth = "http://localhost:24832/Venta.svc/Venta";

            try
            {
                



                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URLAuth);
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string clienteJson = reader.ReadToEnd();
                JavaScriptSerializer JsonConvert = new JavaScriptSerializer();
                List<Venta> registros = new List<Venta>();
                registros = JsonConvert.Deserialize<List<Venta>>(clienteJson);
                dgvVenta.AutoGenerateColumns = false;
                dgvVenta.DataSource = registros;


            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);

                MessageBox.Show(mensaje,
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            int count = 0;
            for (int i = 0; i <= dgvVenta.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dgvVenta.Rows[i].Cells["Column1"].Value) == true)
                {
                    ++count;
                }
            }


            if (count == 0)
            {
                MessageBox.Show("Debe seleccionar por lo menos una Venta",
                "Adventencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
                return;
            }

            DialogResult result = MessageBox.Show("¿Está Seguro que desea Imprimir la Venta?",
            "Atencion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Imprimiendo....");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConsultarCliente frmCliente = new ConsultarCliente();
            frmCliente.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarCliente frmCliente = new ConsultarCliente();
            frmCliente.ShowDialog();
        }

        private void RegistrarVenta_Load(object sender, EventArgs e)
        {

            if (this.tabControl1.TabPages.Contains(this.tabPage2))
                this.tabControl1.TabPages.Remove(this.tabPage2);
            else
                this.tabControl1.TabPages.Add(this.tabPage2);

            rbDni.Checked = true;
            rbVenta.Checked = false;
            Listar("1","1");

        }

   
        public void Listar( string busqueda, string valor)
        {
            try
            {
                dgvVenta.AutoGenerateColumns = false;
                //dgvVenta.DataSource = daoproducto.ListarProducto();
                string URLAuth = "http://localhost:24832/Venta.svc/Venta/" + busqueda.ToString() + "/" + valor.ToString();

                HttpWebRequest req = (HttpWebRequest)WebRequest.
                    Create(URLAuth);
                req.Method = "GET";

                req.ContentType = "application/json";

                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string clienteJson = reader.ReadToEnd();
                JavaScriptSerializer JsonConvert = new JavaScriptSerializer();
                List<Venta> registros = new List<Venta>();
                registros = JsonConvert.Deserialize<List<Venta>>(clienteJson);
                dgvVenta.DataSource = registros;


            }
            catch (WebException ex)
            {
                HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
                string message = ((HttpWebResponse)ex.Response).StatusDescription;
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);

                MessageBox.Show(mensaje,
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);

            }
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.TabPages.Contains(this.tabPage2))
                this.tabControl1.TabPages.Remove(this.tabPage2);
            else
                this.tabControl1.TabPages.Add(this.tabPage2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtBusCliente.Text.Trim().Length == 0)
            {
                Listar("1", "1");
                return;
            }
            if (rbDni.Checked)
                Listar("2",txtBusCliente.Text);

            if (rbVenta.Checked)
                Listar("3", txtBusCliente.Text);
        }
    }
}
