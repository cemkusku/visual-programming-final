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
    public partial class görünenmüsteriler : Form
    {
        public görünenmüsteriler()
        {
            InitializeComponent();
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
        private void Clear()
        {
            CustNameTb.Text = "";
            CustGenCb.SelectedIndex = -1;
            CustPhoneTb.Text = "";
            CustAddTb.Text = "";
        }

        string Customer;
        int Key = 0;
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Customer = CustNameTb.Text;
            CustNameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustAddTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CustPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
            CustGenCb.SelectedItem = CustomerDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (CustNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
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
                    Clear();
                    ShowMusteri();
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            giris Obj = new giris();
            this.Hide();
            Obj.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            görünenrezervasyon Obj = new görünenrezervasyon();
            Obj.Show();
            this.Hide();
        }
    }
}
