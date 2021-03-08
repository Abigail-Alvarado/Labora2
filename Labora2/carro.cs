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
    public partial class carro : Form
    {
        List<vehiculos> vehiculos = new List<vehiculos>();
        string archivoV = "Registrovehículos.txt";
        public carro()
        {
            InitializeComponent();
        }
        public void guardar()
        {
            FileStream stream = new FileStream(archivoV, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            for (int i = 0; i < vehiculos.Count; i++)
            {
                writer.WriteLine(vehiculos[i].Placa);
                writer.WriteLine(vehiculos[i].Marca);
                writer.WriteLine(vehiculos[i].Modelo);
                writer.WriteLine(vehiculos[i].Color);
                writer.WriteLine(vehiculos[i].Preciok);
            }
            writer.Close();
        }
        void leer_datos()
        {
            FileStream stream = new FileStream(archivoV, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                vehiculos tempvehiculos = new vehiculos();
                tempvehiculos.Placa = reader.ReadLine();
                tempvehiculos.Marca = reader.ReadLine();
                tempvehiculos.Modelo = reader.ReadLine();
                tempvehiculos.Color = reader.ReadLine();
                tempvehiculos.Preciok = float.Parse(reader.ReadLine());
                vehiculos.Add(tempvehiculos);

            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }
        void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            comboBox1.Text = null;
            textBox5.Text = null;
        }

        private int verificar_repeticion(string placa) 
        {
            int resultado = 0;
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i].Placa.Contains(placa))
                    resultado = 1;
            }
            return resultado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 vmenu = new Form1();
            vmenu.Show();
            this.SetVisibleCore(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vehiculos tempvehiculo = new vehiculos();
            tempvehiculo.Placa = textBox1.Text;
            tempvehiculo.Marca = textBox2.Text;
            tempvehiculo.Modelo = textBox3.Text;
            tempvehiculo.Color = comboBox1.Text;
            tempvehiculo.Preciok = float.Parse(textBox5.Text);

            if (verificar_repeticion(textBox1.Text) != 1)
            {
                vehiculos.Add(tempvehiculo);
                guardar();
                limpiar();
                MessageBox.Show("Vehiculo agregado correctamente");
            }
            else
            {
                MessageBox.Show("No se pueden agregar vehiculos repetidos en la base de datos");
            }
        }

        private void carro_Load(object sender, EventArgs e)
        {
            leer_datos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
