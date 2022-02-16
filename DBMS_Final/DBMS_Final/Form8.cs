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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");

        private void Form8_Load(object sender, EventArgs e) //Not görüntüleme
        {
            baglanti.Open();
            string query = "select OgrenciDersID,Vize,Final,Butunleme,[Gecme Notu],[Gecme Durumu],OgrenciDonem from NotTable where NotTable.OgrenciDersID in (select OgrenciDersID from OgrenciDersTable where OgrenciNo ='" + Convert.ToInt32(Form1.form_variable) + "' ) "; 
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, baglanti);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Close();

            baglanti.Open();
            string query = "select DersID from OgrenciDersTable where OgrenciDersID = '" + Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'";
            SqlCommand cmd = new SqlCommand(query, baglanti);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            textBox1.Text = Convert.ToString(reader.GetValue(0));
            reader.Close();
            baglanti.Close();


            baglanti.Open();
            string query2 = "select DersAdi from DersTable where DersID = '" + Convert.ToInt32(textBox1.Text) + "'";
            SqlCommand cmd2 = new SqlCommand(query2, baglanti);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            textBox2.Text = Convert.ToString(reader2.GetValue(0));
            reader2.Close();

            baglanti.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
