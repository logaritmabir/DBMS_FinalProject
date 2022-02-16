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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-7R1GKNS\\FORMAT;Initial Catalog=UBS;Integrated Security=True");

        private void Form6_Load(object sender, EventArgs e)
        {
            BolumIDgetir();
        }
        void BolumIDgetir()
        {
            baglanti.Open();

            string query = "select BolumID from BolumTable"; //BölümID lerini comboboxa çekme,combobox flutterdaki gibi basınca seçeneklerin çıktığı kutu hasta doktor
            SqlCommand cmd = new SqlCommand(query, baglanti);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            while (reader.Read())
            {
                comboBox3.Items.Add(reader.GetString(0));
                comboBox2.Items.Add(reader.GetString(0));
            }

            reader.Close();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand sqlCommand2 = new SqlCommand("Insert into USERTable (USERTC) values ('" + textBox4.Text + "')", baglanti); //Öğrenci ekleme kısmı,textboxlara girdiğimiz verileri öğrenci table a insert lüyor ve tc leri USERTC tablosuna aktarıyor,sistemde herkesin tc si farklı olacağı için
                sqlCommand2.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                string query = "Insert into OgrenciTable (OgrenciAd,OgrenciSoyad,OgrenciTC,OgrenciBolumID,OgrenciDanismanID) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + comboBox3.Text + "','" + Convert.ToInt32(comboBox1.Text) + "')";
                SqlCommand sqlCommand = new SqlCommand(query, baglanti);
                sqlCommand.ExecuteNonQuery();
                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();

            BolumIDgetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand sqlCommand2 = new SqlCommand("Insert into USERTable (USERTC) values ('" + textBox9.Text + "')", baglanti); // Aynı şekilde öğretmen ekleme
                sqlCommand2.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                string query = "Insert into OgretmenTable (OgretmenAd,OgretmenSoyad,OgretmenBolumID,OgretmenTC) values('" + textBox12.Text + "','" + textBox11.Text + "','" + comboBox2.Text + "','" + textBox9.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(query, baglanti);
                sqlCommand.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
            textBox12.Clear();
            textBox11.Clear();
            textBox9.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void DanismanIDgetir()
        {
            baglanti.Open();
            string query = "select OgretmenID from OgretmenTable where OgretmenBolumID = '" + comboBox3.Text + "' ";
            SqlCommand sqlCommand = new SqlCommand(query,baglanti);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetValue(0));
            }
            reader.Close();
            baglanti.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DanismanIDgetir();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DanismanIDgetir();
        }
    }
}
