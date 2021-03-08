using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Labora2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cliente vclientes = new cliente();
            vclientes.Show();
            this.SetVisibleCore(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            carro carr = new carro();
            carr.Show();
            this.SetVisibleCore(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alquilado vclientes = new Alquilado();
            vclientes.Show();
            this.SetVisibleCore(false);
        }
    }
}
