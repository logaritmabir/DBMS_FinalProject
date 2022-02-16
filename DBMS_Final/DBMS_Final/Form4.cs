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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox4.Text = Form1.form_variable;

            baglanti.Open();

            string query = "select * from OgretmenTable where OgretmenID = '" + textBox4.Text + "'"; //Öğretmen bilgilerini çekme
            SqlCommand cmd = new SqlCommand(query, baglanti);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            textBox1.Text = reader.GetString(1); //Öğretmen bilgilerini yazdırma
            textBox2.Text = reader.GetString(2);
            textBox3.Text = reader.GetString(3);

            reader.Close();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from OgrenciTable where OgrenciDanismanID = '"+ Convert.ToInt32(textBox4.Text) + "'", baglanti); //Danışmanlığını yaptığımız öğrencileri çekme
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter("select DersID,DersAdi from DersTable where DersID in (select OgretmenDersTable.DersID from OgretmenDersTable where OgretmenID = '"+Convert.ToInt32(textBox4.Text) +"')", baglanti); //Öğretmenin verdiği dersler
            DataTable dataTable2 = new DataTable();
            sqlDataAdapter2.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Danışman Onay Sayfası");
            Form f = new Form10();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Giriş Sayfası");
            Form f = new Form9();
            f.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
