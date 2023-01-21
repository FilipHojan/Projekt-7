using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Biblioteka_online.Form1;

namespace Biblioteka_online
{
    public partial class Form3 : Form
    {
        private Form1 form1;

        public Form3(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                int numer = (from DataGridViewRow row in form1.dataGridView2.Rows
                             where row.Cells[4].FormattedValue != string.Empty
                             select Convert.ToInt32(row.Cells[4].FormattedValue)).Max();

                numer += 1;
                string ID = numer.ToString();
                List<ksiazka> empList = new List<ksiazka>();
                ksiazka ksiazkaxml = new ksiazka();
                ksiazkaxml.tytul = textBox1.Text;
                ksiazkaxml.autor = textBox2.Text;
                ksiazkaxml.stan = "FALSE";
                ksiazkaxml.ID = ID;
                ksiazkaxml.idu = "";
                empList.Add(ksiazkaxml);

                foreach (var rekord in empList)
                {
                    dtk.Rows.Add(rekord.tytul, rekord.autor, rekord.stan, rekord.ID, rekord.idu);
                }
                form1.dataGridView2.DataSource = dtk;
            }
            else
            {
                MessageBox.Show("Puste pola niedozwolone", "Nie można dodać książki", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
