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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");
        private void Form9_Load(object sender, EventArgs e)
        {
            NotListele();
        }
        void NotListele()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select NotID,NotTable.OgrenciDonem,Vize,Final,Butunleme,[Gecme Notu],[Gecme Durumu]  from NotTable where NotTable.OgrenciDersID in (select OgrenciDersID from OgrenciDersTable where DersID in (select DersID from OgretmenDersTable where OgretmenID = '"+Form1.form_variable+ "'))", baglanti);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                SqlCommand cmd = new SqlCommand("update NotTable set Vize = '" + Convert.ToInt32(textBox1.Text) + "',Final = '" + Convert.ToInt32(textBox2.Text) + "',Butunleme = '" + Convert.ToInt32(textBox3.Text) + "' where NotID = ('" + dataGridView1.CurrentRow.Cells[0].Value + "') ", baglanti);
                cmd.ExecuteNonQuery();

                baglanti.Close();

                if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value) == 0) //Ders notu girme ve başarılı başarısız kararı,Büt notu yoksa final + vize
                {
                    baglanti.Open();

                    SqlCommand cmd2 = new SqlCommand("update NotTable set [Gecme Notu] = '"+((Convert.ToInt32(textBox1.Text)*0.4)+(Convert.ToInt32(textBox2.Text) * 0.6)) + "' where NotID = ('" + dataGridView1.CurrentRow.Cells[0].Value + "') ", baglanti);
                    cmd2.ExecuteNonQuery();

                    baglanti.Close();
                    Gectimi();
                    NotListele();

                }
                else if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value) != 0) // büt varsa büt +vize
                {
                    baglanti.Open();

                    SqlCommand cmd3 = new SqlCommand("update NotTable set [Gecme Notu] = '" + ((Convert.ToInt32(textBox1.Text) * 0.4) + (Convert.ToInt32(textBox3.Text) * 0.6)) + "' where NotID = ('" + dataGridView1.CurrentRow.Cells[0].Value + "')", baglanti);
                    cmd3.ExecuteNonQuery();

                    baglanti.Close();
                    Gectimi();
                    NotListele();

                }
                baglanti.Close();
                Gectimi();
                NotListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Gectimi()
        {
            baglanti.Open(); //Başarılı başarısız

            SqlCommand cmd = new SqlCommand("update NotTable set [Gecme Durumu] = 'Basarili' where NotTable.[Gecme Notu] >= 60 and NotID ='"+ dataGridView1.CurrentRow.Cells[0].Value + "'", baglanti);
            SqlCommand cmd2 = new SqlCommand("update NotTable set [Gecme Durumu] = 'Basarisiz' where NotTable.[Gecme Notu] < 60 and NotID = '" + dataGridView1.CurrentRow.Cells[0].Value + "' ", baglanti);
            cmd2.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

            baglanti.Close();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
