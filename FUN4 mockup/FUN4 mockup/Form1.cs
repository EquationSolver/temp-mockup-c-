using FUN4_mockup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FUN4_mockup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputParser parser = new InputParser();
            Node n = parser.parseInput(textBox1.Text);
            n.Calculate();
            MessageBox.Show(n.Print());
        }
    }
}
