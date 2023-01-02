using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace WindowsFormsApp1
{
    public partial class panel : Form
    {
        public panel()
        {
            InitializeComponent();
            CountVehicles();
            CountUsers();
            CountDrivers();
            CountBookings();
            CountCust();
            SumAmt();
            BestCust();
            BestDriver();
        }
        private void CountVehicles()
        {
            string Query = "select count(*) from araclar";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            VNumLbl.Text = dt.Rows[0][0].ToString();
        }
        private void CountUsers()
        {
            string Query = "select count(*) from kullanıcı";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            UNumLbl.Text = dt.Rows[0][0].ToString();
        }
        private void CountDrivers()
        {
            string Query = "select count(*) from suruculer";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DNumLbl.Text = dt.Rows[0][0].ToString();
        }
        private void CountBookings()
        {
            string Query = "select count(*) from rezervasyon";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BookNumLbl.Text = dt.Rows[0][0].ToString();
        }
        private void CountCust()
        {
            string Query = "select count(*) from musteri";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CNumLbl.Text = dt.Rows[0][0].ToString();
        }
        private void SumAmt()
        {
            string Query = "select Sum(ucret) from rezervasyon";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            IncNumLbl.Text =dt.Rows[0][0].ToString();
        }
        private void BestCust()
        {
            string InnerQuery = "select Max(ucret) from rezervasyon";
            MySqlDataAdapter sda1 = new MySqlDataAdapter(InnerQuery, DB.baglanti());
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            string Query = "select musteri_adi from rezervasyon where ucret='"+ dt1.Rows[0][0].ToString() +"'";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BestCustLbl.Text = dt.Rows[0][0].ToString();
        }
        private void BestDriver()
        {
            string Query = "select surucu, Count(*) from rezervasyon Group By surucu Order By Count(surucu) DESC";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BestDriverLbl.Text = dt.Rows[0][0].ToString();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            rezervasyon Obj = new rezervasyon();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            arac Obj = new arac();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            musteri Obj = new musteri();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Suruculer Obj = new Suruculer();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            giris Obj = new giris();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            kullanicilar Obj = new kullanicilar();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            kullanicilar Obj = new kullanicilar();
            Obj.Show();
            this.Hide();
        }
    }
}
