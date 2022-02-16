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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            DersKayıtListele();
        }
        void DersKayıtListele() // Ders seçim ekranına eklediğimiz dersleri çekiyoruz
        {
            string query = "select * from OgrenciDersTable where OgrenciNo = '" + Convert.ToInt32(Form1.form_variable) + "'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, baglanti);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e) // Dersi silme
        {
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("delete from OgrenciDersTable where OgrenciDersID = ('" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) + "')", baglanti);
            cmd.ExecuteNonQuery();

            baglanti.Close();
            DersKayıtListele();
        }

        private void button1_Click(object sender, EventArgs e) //Dersi danışman onaya gönderme
        {
            baglanti.Open();

            SqlCommand cmd = new SqlCommand("update OgrenciDersTable set DanismanOnay = '" +(" Onay Bekleniyor ") + "' where OgrenciDersID = ('"+ Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)+ "') ", baglanti);
            cmd.ExecuteNonQuery();

            baglanti.Close();
            DersKayıtListele();
        }
    }
}
