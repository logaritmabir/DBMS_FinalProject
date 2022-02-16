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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");

        private void Form10_Load(object sender, EventArgs e)
        {
            DanismanOnayListele();
        }
        void DanismanOnayListele()
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select OgrenciDersID,OgrenciTable.OgrenciNo,concat(OgrenciTable.OgrenciAd,' ',OgrenciTable.OgrenciSoyad) as Ogrenci,DanismanOnay,concat(OgretmenAd,' ',OgretmenSoyad) as Danisman,DersAdi,OgrenciDonem from OgrenciTable,OgrenciDersTable,OgretmenTable,DersTable where OgrenciTable.OgrenciDanismanID = '" + Form1.form_variable + "' and OgrenciDersTable.OgrenciNo = OgrenciTable.OgrenciNo and OgrenciDersTable.DanismanOnay like ' Onay%' and OgretmenAd = (select OgretmenAd from OgretmenTable where OgretmenID = '" + Form1.form_variable+"') and OgrenciDersTable.DersID = DersTable.DersID ;", baglanti);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Danışman onay
        {
            baglanti.Open();


            string sql = "insert into NotTable (OgrenciDersID,OgrenciDonem) values ('"+ Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) + "','"+ Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value) + "' )";
            SqlCommand sqlCommand = new SqlCommand(sql,baglanti);
            sqlCommand.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("update OgrenciDersTable set DanismanOnay = '" + (" Kesin Kayıt ") + "' where OgrenciDersID = ('" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) + "') ", baglanti);
            cmd.ExecuteNonQuery();




            baglanti.Close();
            DanismanOnayListele();
        }
    }
}
