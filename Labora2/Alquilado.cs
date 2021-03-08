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
        string archivo1 = "Registroclientes.txt";
        List<vehiculos> vehiculos = new List<vehiculos>();
        string archivo2 = "Registrovehículos.txt";
        List<Alquilados> alquilados = new List<Alquilados>();
        string archivo4 = "alquilados.txt";
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
            FileStream stream = new FileStream(archivo1, FileMode.Open, FileAccess.Read);
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


            FileStream stream2 = new FileStream(archivo2, FileMode.Open, FileAccess.Read);
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




            FileStream stream4 = new FileStream(archivo4, FileMode.Open, FileAccess.Read);
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
            FileStream stream2 = new FileStream(archivo4, FileMode.OpenOrCreate, FileAccess.Write);
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
    }
}
