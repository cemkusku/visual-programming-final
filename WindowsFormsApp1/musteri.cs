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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
            ShowMusteri();
        }
        private void Clear()
        {
            CustNameTb.Text = "";
            CustGenCb.SelectedIndex = -1;
            CustPhoneTb.Text = "";
            CustAddTb.Text = "";

        }

        private void ShowMusteri()
        {
            string Query = "select * from musteri";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "" || CustGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("insert into musteri(musteri_adi,musteri_adres,musteri_telno,musteri_cinsiyet) values(@CN,@CA,@CP,@CG)", DB.baglanti());
                    cmd.Parameters.AddWithValue("@CN", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CustAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CustPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CG", CustGenCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Başarıyla Kaydedildi");
                    ShowMusteri();
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int Key = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Müşteri Seçiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete from musteri where musteri_id=@RezKey", DB.baglanti());
                    cmd.Parameters.AddWithValue("@RezKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Başarıyla Silindi");
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }
        string Customer;
        private void CountBookingByCust()
        {
            string Query = "select count(*) from rezervasyon where musteri_adi='" + Customer + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BNumLbl.Text = dt.Rows[0][0].ToString();
        }
        private void SumAmt()
        {
            string Query = "select sum(ucret) from rezervasyon where ucret='" + Customer + "'";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            TotAmtLbl.Text = dt.Rows[0][0].ToString();
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            Customer = CustNameTb.Text;
            CustNameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustAddTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CustPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
            CustGenCb.SelectedItem = CustomerDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (CustNameTb.Text=="")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
                CountBookingByCust();
                SumAmt();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CustNameTb.Text == "" || CustAddTb.Text == "" || CustPhoneTb.Text == "" || CustGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update musteri set musteri_adi=@CN,musteri_adres=@CA,musteri_telno=@CP,musteri_cinsiyet=@CG where musteri_id=@CKey" , DB.baglanti());
                    cmd.Parameters.AddWithValue("@CN", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@CA", CustAddTb.Text);
                    cmd.Parameters.AddWithValue("@CP", CustPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@CG", CustGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@CKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Başarıyla Düzenlendi");
                    ShowMusteri();
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Suruculer Obj = new Suruculer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            arac Obj = new arac();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            rezervasyon Obj = new rezervasyon();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel Obj = new panel();
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
            Obj.Show();
            this.Hide();
        }
    }
}
