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
    public partial class Form2 : Form
    {
        private Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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
                int numer = (from DataGridViewRow row in form1.dataGridView1.Rows
                             where row.Cells[2].FormattedValue != string.Empty
                             select Convert.ToInt32(row.Cells[2].FormattedValue)).Max();
                numer += 1;
                string ID = numer.ToString();
                List<uzytkownik> empList = new List<uzytkownik>();
                uzytkownik uzytkownikxml = new uzytkownik();
                uzytkownikxml.imie = textBox1.Text;
                uzytkownikxml.nazwisko = textBox2.Text;
                uzytkownikxml.ID = ID;
                uzytkownikxml.idk = "";
                empList.Add(uzytkownikxml);

                foreach (var rekord in empList)
                {
                    dtu.Rows.Add(rekord.imie, rekord.nazwisko, rekord.ID, rekord.idk);
                }
                form1.dataGridView1.DataSource = dtu;
            }
            else
            {
                MessageBox.Show("Puste pola niedozwolone", "Nie można dodać użytkownika", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
