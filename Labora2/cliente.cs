using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Labora2
{
    public partial class cliente : Form
    {
        List<clientes> clientes = new List<clientes>();
        string archivoC = "Registroclientes.txt";
        public cliente()
        {
            InitializeComponent();
        }
        public void guardar()
        {
            FileStream stream = new FileStream(archivoC, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < clientes.Count; i++)
            {
                writer.WriteLine(clientes[i].Nit);
                writer.WriteLine(clientes[i].Nombre);
                writer.WriteLine(clientes[i].Direccion);
            }
            writer.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivoC, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                clientes tempcliente = new clientes();
                tempcliente.Nit = reader.ReadLine();
                tempcliente.Nombre = reader.ReadLine();
                tempcliente.Direccion = reader.ReadLine();
                clientes.Add(tempcliente);

            }
            reader.Close();
        }
        void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 vmenu = new Form1();
            vmenu.Show();
            this.SetVisibleCore(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //declaramos un objeto cliente de la clase clientes
                clientes tempcliente = new clientes();
                tempcliente.Nit = textBox1.Text;
                tempcliente.Nombre = textBox2.Text;
                tempcliente.Direccion = textBox3.Text;
                //para asignarle los datos leidos del archivo
                clientes.Add(tempcliente);
                //luego guardar el tempcliente en la lista de clienters
                guardar();

                limpiar();
                MessageBox.Show("Cliente agregado correctamente");
            }
            catch (Exception)
            {
                // Condición para emitir si falta en llenar un campo
                MessageBox.Show("No se han llenado todos los datos", "Mi Mesaje Predeterminado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cliente_Load(object sender, EventArgs e)
        {
            leer_datos();
        }
    }
}

