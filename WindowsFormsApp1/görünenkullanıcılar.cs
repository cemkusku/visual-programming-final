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
    public partial class görünenkullanıcılar : Form
    {
        public görünenkullanıcılar()
        {
            InitializeComponent();
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Clear()
        {
            UnameTb.Text = "";
            PhoneTb.Text = "";
            PasswordTb.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PhoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("insert into kullanıcı(kullanici_adi,kullanici_telno,sifre) values (@UN,@UP,@UPa)", DB.baglanti());
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPa", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Kaydedildi");
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }
        int Key = 0;
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PhoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update kullanıcı set kullanici_adi=@UN,kullanici_telno=@UP,sifre=@UPa where kullanici_id =@CKey", DB.baglanti());
                    cmd.Parameters.AddWithValue("@UN", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPa", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Müşteri Başarıyla Kaydedildi");
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Kullanıcı Seçiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete from kullanıcı where kullanici_id=@UKey", DB.baglanti());
                    cmd.Parameters.AddWithValue("@UKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kullanıcı Başarıyla Silindi");
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            giris Obj = new giris();
            Obj.Show();
            this.Hide();
        }

        private void PhoneTb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
