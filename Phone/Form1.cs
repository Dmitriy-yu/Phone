using Phone.LIST;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Phone
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        Query controller;
        public Form1()
        {
            InitializeComponent();
            controller = new Query(Connect.Conn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpgRade();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.Add(textBox1.Text, textBox2.Text, textBox3.Text);
            dataGridView1.DataSource = controller.UpgRade();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Delete(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value.ToString()));
            dataGridView1.DataSource = controller.UpgRade();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;
            string time = " ";
            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }
            time += ":";
            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }
            time += ":";
            if (s<10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }
            label2.Text = time;
           
            string daymans = ""; //дата и месяц
            int d = DateTime.Now.Day;
            int ma= DateTime.Now.Month;
            int y = DateTime.Now.Year;
            if (d < 10)
            {
                daymans += "0" + d;
            }
            else
            {
                daymans += d;
            }
            daymans += ":";
            if (ma < 10)
            {
                daymans += "0" + ma;
            }

            else
            {
                daymans += ma;
            }
            daymans += ":";
            daymans += y;
            daymans += " г.";

            label1.Text = daymans;
        }

        private void button4_Click(object sender, EventArgs e)//Поисковик
        {
            bool found = false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value!=null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox4.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                           dataGridView1.FirstDisplayedScrollingRowIndex = i;
                            found = true;
                            break;
                        }
                    }
                }
                if (found)
                {
                    break;

                }
            }
            if (!found)
            {
                MessageBox.Show("Не найдено", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            textBox1.Clear();
            
        }
        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox4.Clear();
        }
    }
}
                     
             





           
