using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteka_online
{
    public partial class Form1 : Form
    {

        public static DataSet dataSetU = new DataSet();
        public static DataTable dtu = new DataTable();
        public static DataSet dataSetK = new DataSet();
        public static DataTable dtk = new DataTable();

        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            dtu.Columns.Add("Imie");
            dtu.Columns.Add("Nazwisko");
            dtu.Columns.Add("ID");
            dtu.Columns.Add("idk");
            dataGridView1.DataSource = dtu;
            dtk.Columns.Add("Tytul");
            dtk.Columns.Add("Autor");
            dtk.Columns.Add("Stan");
            dtk.Columns.Add("ID");
            dtk.Columns.Add("idu");
            dataGridView2.DataSource = dtk;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public class ksiazka
        {
            public string ID;
            public string tytul;
            public string autor;
            public string stan;
            public string idu;
        }

        public class uzytkownik
        {
            public string imie;
            public string nazwisko;
            public string ID;
            public string idk;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            dataSetU.Tables.Clear();
            dataSetU.Tables.Add(dtu);
            dataSetU.WriteXml(openFileDialog.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files|*.xml";
            openFileDialog.ShowDialog(this);
            dataSetU.ReadXml(openFileDialog.FileName);
            List<uzytkownik> empList = new List<uzytkownik>();
            foreach (DataRow dr in dataSetU.Tables[0].Rows)
            {
                uzytkownik uzytkownikxml = new uzytkownik();
                uzytkownikxml.imie = dr.Field<string>("Imie");
                uzytkownikxml.nazwisko = dr.Field<string>("Nazwisko");
                uzytkownikxml.ID = dr.Field<string>("ID");
                uzytkownikxml.idk = dr.Field<string>("idk");
                empList.Add(uzytkownikxml);
            }
            foreach (var rekord in empList)
            {
                dtu.Rows.Add(rekord.imie, rekord.nazwisko, rekord.ID, rekord.idk);
            }
            dataGridView1.DataSource = dtu;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(this);
            f3.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(row.Index);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog(this);
            dataSetK.Tables.Clear();
            dataSetK.Tables.Add(dtk);
            dataSetK.WriteXml(openFileDialog.FileName);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files|*.xml";
            openFileDialog.ShowDialog(this);
            dataSetK.ReadXml(openFileDialog.FileName);
            List<ksiazka> empList = new List<ksiazka>();
            foreach (DataRow dr in dataSetK.Tables[0].Rows)
            {
                ksiazka ksiazkaxml = new ksiazka();
                ksiazkaxml.tytul = dr.Field<string>("Tytul");
                ksiazkaxml.autor = dr.Field<string>("Autor");
                ksiazkaxml.stan = dr.Field<string>("Stan");
                ksiazkaxml.ID = dr.Field<string>("ID");
                ksiazkaxml.idu = dr.Field<string>("idu");
                empList.Add(ksiazkaxml);
            }
            foreach (var rekord in empList)
            {
                dtk.Rows.Add(rekord.tytul, rekord.autor, rekord.stan, rekord.ID, rekord.idu);
            }
            dataGridView2.DataSource = dtk;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dtu.Rows[dataGridView1.CurrentCell.RowIndex][3].ToString() == "")
            {
                if (dtk.Rows[dataGridView2.CurrentCell.RowIndex][2].ToString() == "TRUE")
                {
                    dtu.Rows[dataGridView1.CurrentCell.RowIndex].SetField("idk", dtk.Rows[dataGridView2.CurrentCell.RowIndex].Field<string>("ID"));
                    dtk.Rows[dataGridView2.CurrentCell.RowIndex].SetField("idu", dtu.Rows[dataGridView1.CurrentCell.RowIndex].Field<string>("ID"));
                    dtk.Rows[dataGridView2.CurrentCell.RowIndex].SetField("Stan", "FALSE");
                }
                else
                {
                    MessageBox.Show("Książka jest wypożyczona", "Nie można wypożyczyć", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Użytkownik ma już wypożyczoną książkę", "Nie można wypożyczyć", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.DataSource = dtu;
            dataGridView2.DataSource = dtk;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dtk.Rows[dataGridView2.CurrentCell.RowIndex][2].ToString() == "FALSE")
            {
                dtk.Rows[dataGridView2.CurrentCell.RowIndex][2] = "TRUE";
                for (int i = 0; i < dtu.Rows.Count; i++)
                {
                    if (dtu.Rows[i][2].ToString() == dtk.Rows[dataGridView2.CurrentCell.RowIndex][4].ToString())
                    {
                        dtu.Rows[i][3] = "";
                    }
                }
                dtk.Rows[dataGridView2.CurrentCell.RowIndex][4] = "";

            }
            else
            {
                MessageBox.Show("Książka nie jest wypożyczona", "Nie można zwrócić", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
