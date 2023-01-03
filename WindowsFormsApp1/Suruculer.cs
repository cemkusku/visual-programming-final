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
    public partial class Suruculer : Form
    {
        public Suruculer()
        {
            InitializeComponent();
            ShowSuruculer();
        }
        private void Clear()
        {
            DrNameTb.Text = "";
            GenCb.SelectedIndex = -1;
            PhoneNmTb.Text = "";
            DrAddTb.Text = "";

        }

        private void ShowSuruculer()
        {
            string Query = "select * from suruculer";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DriverDGV.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DrNameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneNmTb.Text == "" || DrAddTb.Text == "" || RatingCb.SelectedIndex==-1)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("insert into suruculer(isim, telefon_num, adres, dogmgunu, ise_gir_tar, cinsiyeti, degerlendirme) " +
                        "values(@isim,@Dtelefon_num,@adres,@dogmgunu,@giris_tarihi,@cinsiyet,@degerlendirme)", DB.baglanti());
                    cmd.Parameters.AddWithValue("@isim", DrNameTb.Text);
                    cmd.Parameters.AddWithValue("@Dtelefon_num", PhoneNmTb.Text);
                    cmd.Parameters.AddWithValue("@adres", DrAddTb.Text);
                    cmd.Parameters.AddWithValue("@dogmgunu", DOB.Value);
                    cmd.Parameters.AddWithValue("@giris_tarihi", JoinDate.Value);
                    cmd.Parameters.AddWithValue("@cinsiyet", GenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@degerlendirme", RatingCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sürücü Başarıyla Kaydedildi");
                    ShowSuruculer();
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

        int Rate;
        private void GetStarts()
        {
            Rate = Convert.ToInt32(DriverDGV.SelectedRows[0].Cells[7].Value.ToString());
            RateLbl.Text = "" + Rate;
            if (Rate == 1 || Rate == 2 ) 
            {
                LevelLbl.Text = "İyi";
                LevelLbl.ForeColor = Color.Red;
            }
            else if (Rate == 3 || Rate == 4)
            {
                LevelLbl.Text = "Güzel";
                LevelLbl.ForeColor = Color.Blue;
            }
            else
            {
                LevelLbl.Text = "Mükemmel";
                LevelLbl.ForeColor = Color.Green;
            }
        }

        int Key = 0;
        private void DriverDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DrNameTb.Text = DriverDGV.SelectedRows[0].Cells[1].Value.ToString();
            PhoneNmTb.Text = DriverDGV.SelectedRows[0].Cells[2].Value.ToString();
            DrAddTb.Text = DriverDGV.SelectedRows[0].Cells[3].Value.ToString();
            DOB.Text = DriverDGV.SelectedRows[0].Cells[4].Value.ToString();
            JoinDate.Text = DriverDGV.SelectedRows[0].Cells[5].Value.ToString();
            GenCb.Text = DriverDGV.SelectedRows[0].Cells[6].Value.ToString();
            RatingCb.Text = DriverDGV.SelectedRows[0].Cells[7].Value.ToString();
            if (DrNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DriverDGV.SelectedRows[0].Cells[0].Value.ToString());
                GetStarts();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Sürücü Seçiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete from suruculer where surucu_id=@DrKey", DB.baglanti());
                    cmd.Parameters.AddWithValue("@DrKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sürücü Başarıyla Silindi");
                    ShowSuruculer();
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (DrNameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneNmTb.Text == "" || DrAddTb.Text == "" || RatingCb.SelectedIndex == -1)
            {
                MessageBox.Show("Sürücü Seçiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update suruculer set isim=@isim, telefon_num=@Dtelefon_num, adres=@adres, dogmgunu=@dogmgunu, ise_gir_tar=@giris_tarihi, cinsiyeti=@cinsiyet, degerlendirme=@degerlendirme where surucu_id=@DrKey", DB.baglanti());
                    cmd.Parameters.AddWithValue("@isim", DrNameTb.Text);
                    cmd.Parameters.AddWithValue("@Dtelefon_num", PhoneNmTb.Text);
                    cmd.Parameters.AddWithValue("@adres", DrAddTb.Text);
                    cmd.Parameters.AddWithValue("@dogmgunu", DOB.Value);
                    cmd.Parameters.AddWithValue("@giris_tarihi", JoinDate.Value);
                    cmd.Parameters.AddWithValue("@cinsiyet", GenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@degerlendirme", RatingCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DrKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sürücü Başarıyla Güncellendi");
                    ShowSuruculer();
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            musteri Obj = new musteri();
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            giris Obj = new giris();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel Obj = new panel();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            kullanicilar Obj = new kullanicilar();
            Obj.Show();
            this.Hide();
        }

        private void PhoneNmTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
