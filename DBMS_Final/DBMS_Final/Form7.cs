using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBMS_Final
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");
        private void button4_Click(object sender, EventArgs e) //Sistemdeki öğrencileri getir
        {
            OgrenciListele();
        }
        void OgrenciListele()
        {
            baglanti.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from OgrenciTable ", baglanti);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            baglanti.Close();
        }
        void OgretmenListele()
        {
            baglanti.Open();

            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("Select * from OgretmenTable ", baglanti);
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e) //Öğretmenleri getir
        {
            OgretmenListele();
        }

        private void button1_Click(object sender, EventArgs e) //Öğrenci güncelle
        {
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("update OgrenciTable set OgrenciAd = '" + textBox1.Text + "',OgrenciSoyad = '" + textBox2.Text + "',OgrenciBolumID = '" + textBox3.Text + "',OgrenciTC = '" + textBox4.Text + "',OgrenciDanismanID = '" + textBox5.Text + "' where OgrenciNo = '" + textBox8.Text + "' ", baglanti);
            cmd.ExecuteNonQuery();

            baglanti.Close();
            OgrenciListele();

        }

        private void button2_Click(object sender, EventArgs e) //öğretmen güncelle
        {
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("update OgretmenTable set OgretmenAd = '" + textBox12.Text + "',OgretmenSoyad = '" + textBox11.Text + "',OgretmenBolumID = '" + textBox10.Text + "',OgretmenTC = '" + textBox9.Text + "' where OgretmenID = '" + textBox13.Text + "' ", baglanti);
            cmd.ExecuteNonQuery();

            baglanti.Close();
            OgretmenListele();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e) //Öğrenci bilgilerini datagridview e 
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e) //Öğretmen bilgilerini datagridview e 
        {
            textBox12.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox11.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox9.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox13.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e) //Dönemi bitir
        {
            try
            {
                baglanti.Open();

                SqlCommand cmd = new SqlCommand("UPDATE OgrenciTable set OgrenciDonem = OgrenciDonem+1;", baglanti);
                cmd.ExecuteNonQuery();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
