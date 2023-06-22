using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace massiv1
{
    public partial class Form1 : Form
    {
        const int MaxArrayLength = 10;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
            dataGridView1.DataSource = array.Select(x => new { Value = x }).ToList();
        }

        private void создатьПервыйМассивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] array = new int[10];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
            dataGridView1.DataSource = array.Select(x => new { Value = x }).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] array = new int[10];


            int sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int val = Convert.ToInt32(row.Cells["Value"].Value);
                if (val % 2 ==0)
                {
                    sum += val;
                    
                }
            }
            
            textBox1.Text = Convert.ToString(sum);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                chart1.Series["Массив"].Points.AddXY("Массив", 
                    (int)Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value));
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void посчитатьСуммуЧетныхЭлементовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] array = new int[10];


            int sum = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int val = Convert.ToInt32(row.Cells["Value"].Value);
                if (val % 2 == 0)
                {
                    sum += val;

                }
            }

            textBox1.Text = Convert.ToString(sum);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //save modifed array in the user file
            FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value);
            sw.Close();
            MessageBox.Show("Данные сохранены!");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamReader sr = File.OpenText(openFileDialog1.FileName);

                string line = sr.ReadLine();

                for (int i = 0; i < MaxArrayLength; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = line;
                    line = sr.ReadLine();
                }

                sr.Close();
            }
        }

       
    }
}
