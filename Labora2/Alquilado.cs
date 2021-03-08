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
    public partial class Alquilado : Form
    {
        List<clientes> clientes = new List<clientes>();
        string archivoC = "Registroclientes.txt";
        List<vehiculos> vehiculos = new List<vehiculos>();
        string archivoV = "Registrovehículos.txt";
        List<Alquilados> alquilados = new List<Alquilados>();
        string archivoA = "Registroalquilados.txt";
        public Alquilado()
        {
            InitializeComponent();
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            textBox1.Enabled = false;
            button3.Visible = true;
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


            FileStream stream2 = new FileStream(archivoV, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);
            while (reader2.Peek() > -1)
            {
                vehiculos tempvehiculos = new vehiculos();
                tempvehiculos.Placa = reader2.ReadLine();
                tempvehiculos.Marca = reader2.ReadLine();
                tempvehiculos.Modelo = reader2.ReadLine();
                tempvehiculos.Color = reader2.ReadLine();
                tempvehiculos.Preciok = float.Parse(reader2.ReadLine());
                vehiculos.Add(tempvehiculos);
            }
            reader2.Close();




            FileStream stream4 = new FileStream(archivoA, FileMode.Open, FileAccess.Read);
            StreamReader reader4 = new StreamReader(stream4);
            while (reader4.Peek() > -1)
            {
                Alquilados tempalquilados = new Alquilados();
                tempalquilados.Nombre = reader4.ReadLine();
                tempalquilados.Placa = reader4.ReadLine();
                tempalquilados.Marca = reader4.ReadLine();
                tempalquilados.Modelo = reader4.ReadLine();
                tempalquilados.Color = reader4.ReadLine();
                tempalquilados.Preciok = float.Parse(reader4.ReadLine());
                tempalquilados.Fechad = Convert.ToDateTime(reader4.ReadLine());
                tempalquilados.Total = float.Parse(reader4.ReadLine());
                alquilados.Add(tempalquilados);

            }
            reader4.Close();
        }
        public void guardar()
        {
            FileStream stream2 = new FileStream(archivoA, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer2 = new StreamWriter(stream2);

            for (int i = 0; i < alquilados.Count; i++)
            {
                writer2.WriteLine(alquilados[i].Nombre);
                writer2.WriteLine(alquilados[i].Placa);
                writer2.WriteLine(alquilados[i].Marca);
                writer2.WriteLine(alquilados[i].Modelo);
                writer2.WriteLine(alquilados[i].Color);
                writer2.WriteLine(alquilados[i].Preciok);
                writer2.WriteLine(alquilados[i].Fechad);
                writer2.WriteLine(alquilados[i].Total);
            }
            writer2.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 vmenu = new Form1();
            vmenu.Show();
            this.SetVisibleCore(false);
        }
        void mostrar()
        {


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = vehiculos;
            dataGridView2.Refresh();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = alquilados;
            dataGridView3.Refresh();


        }

        void encontrarmayor()
        {
            Alquilados tempalquilados = new Alquilados();


            (alquilados = alquilados.OrderByDescending(p => p.Total).ToList()).ToString();
            comboBox3.ValueMember = "Total";
            comboBox3.DataSource = null;
            comboBox3.DataSource = alquilados;
            comboBox3.Refresh();

        }
        void limpiar()
        {
            comboBox1.Text = null;
            comboBox2.Text = null;
            textBox1.Text = null;
            comboBox1.Refresh();
            comboBox2.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Alquilados tempalquilados = new Alquilados();
            tempalquilados.Nombre = comboBox1.SelectedValue.ToString();
            comboBox2.ValueMember = "Placa";
            comboBox2.DataSource = vehiculos;
            tempalquilados.Placa = comboBox2.SelectedValue.ToString();

            comboBox2.ValueMember = "Marca";
            comboBox2.DataSource = vehiculos;
            tempalquilados.Marca = comboBox2.SelectedValue.ToString();


            comboBox2.ValueMember = "Modelo";
            comboBox2.DataSource = vehiculos;
            tempalquilados.Modelo = comboBox2.SelectedValue.ToString();

            comboBox2.ValueMember = "Color";
            comboBox2.DataSource = vehiculos;
            tempalquilados.Color = comboBox2.SelectedValue.ToString();

            comboBox2.ValueMember = "PrecioK";
            comboBox2.DataSource = vehiculos;
            tempalquilados.Preciok = Convert.ToInt32(comboBox2.SelectedValue);
          
            comboBox2.ValueMember = "PrecioK";
            comboBox2.DataSource = vehiculos;
            int kilometro = Convert.ToInt32(comboBox2.SelectedValue);
            int kmrecorrido = Convert.ToInt32(textBox1.Text);
            tempalquilados.Total = (kilometro * kmrecorrido);

            alquilados.Add(tempalquilados);
            guardar();

            limpiar();
            mostrar();
            MessageBox.Show("Alquiler realizado correctamente");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            textBox1.Enabled = true;

            comboBox1.DisplayMember = "Nit";
            comboBox1.ValueMember = "Nombre";
            comboBox1.DataSource = null;
            comboBox1.DataSource = clientes;
            comboBox1.Refresh();

            comboBox2.DisplayMember = "Placa";
            comboBox2.DataSource = null;
            comboBox2.DataSource = vehiculos;
            comboBox2.Refresh();
            button3.Visible = false;
        }

        private void Alquilado_Load(object sender, EventArgs e)
        {
            leer_datos();
            mostrar();
            encontrarmayor();
            label10.Text = "Q " + comboBox3.Text;
            comboBox1.Refresh();
            comboBox2.Refresh();
        }
    }
}
