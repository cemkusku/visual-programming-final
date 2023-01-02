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
    public partial class arac : Form
    {
        public arac()
        {
            InitializeComponent();
            ShowAraclar();
            GetSurucu();
        }
        private void Clear()
        {
            LPlateTb.Text = "";
            MarkaCb.SelectedIndex = -1;
            ModelTb.Text = "";
            VYearCb.SelectedIndex = -1;
            EngTypeCb.SelectedIndex = -1;
            ColorTb.Text = "";
            MilleageTb.Text = "";
            TypeCb.SelectedIndex = -1;
            BookedCb.SelectedIndex = -1;

        }

        private void ShowAraclar()
        {
            string Query = "select * from araclar";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            MySqlCommandBuilder Builder = new MySqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            VehicleDGV.DataSource = ds.Tables[0];
        }
        private void GetSurucu()
        {
            MySqlCommand cmd = new MySqlCommand("select * from suruculer", DB.baglanti());
            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("isim", typeof(string));
            dt.Load(rdr);
            DriverCb.ValueMember = "isim";
            DriverCb.DataSource = dt;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (LPlateTb.Text == "" || MarkaCb.SelectedIndex == -1 || ModelTb.Text == "" || VYearCb.SelectedIndex == -1 || EngTypeCb.SelectedIndex == -1 || ColorTb.Text == "" || MilleageTb.Text == "" || TypeCb.SelectedIndex == -1 || BookedCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("insert into araclar(arac_plaka,arac_marka,arac_model,uretim_yılı,yakit_tipi,arac_renk,arac_kilometre,arac_turu,rezerve,surucu) values(@VP,@Vma,@Vmo,@VY,@VEng,@VCo,@VMi,@VTy,@VB,@Dr)", DB.baglanti());
                    cmd.Parameters.AddWithValue("@VP",LPlateTb.Text);
                    cmd.Parameters.AddWithValue("@Vma", MarkaCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Vmo", ModelTb.Text);
                    cmd.Parameters.AddWithValue("@VY", VYearCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VEng", EngTypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VCo", ColorTb.Text);
                    cmd.Parameters.AddWithValue("@VMi", MilleageTb.Text);
                    cmd.Parameters.AddWithValue("@VTy", TypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VB", BookedCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Dr", DriverCb.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aracınız Başarıyla Kaydedildi");
                    ShowAraclar();
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
            if (LPlateTb.Text == "" )
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("delete from araclar where arac_plaka=@VPlate", DB.baglanti());
                    cmd.Parameters.AddWithValue("@VPlate", LPlateTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Araç Başarıyla Silindi");
                    ShowAraclar();
                    Clear();
                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }

            }
        }
        string V;
        private void CountBookingByVehicle()
        {
            string Query = "select count(*) from rezervasyon where arac='"+V+"'";
            MySqlDataAdapter sda = new MySqlDataAdapter(Query, DB.baglanti());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            VNumLbl.Text = dt.Rows[0][0].ToString();
        }

        private void VehicleDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LPlateTb.Text = VehicleDGV.SelectedRows[0].Cells[0].Value.ToString();
            V = LPlateTb.Text;
            CountBookingByVehicle();
            MarkaCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = VehicleDGV.SelectedRows[0].Cells[2].Value.ToString();
            VYearCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[3].Value.ToString();
            EngTypeCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[4].Value.ToString();
            ColorTb.Text = VehicleDGV.SelectedRows[0].Cells[5].Value.ToString();
            MilleageTb.Text = VehicleDGV.SelectedRows[0].Cells[6].Value.ToString();
            TypeCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[7].Value.ToString();
            BookedCb.SelectedItem = VehicleDGV.SelectedRows[0].Cells[8].Value.ToString();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (LPlateTb.Text == "" || MarkaCb.SelectedIndex == -1 || ModelTb.Text == "" || VYearCb.SelectedIndex == -1 || EngTypeCb.SelectedIndex == -1 || ColorTb.Text == "" || MilleageTb.Text == "" || TypeCb.SelectedIndex == -1 || BookedCb.SelectedIndex == -1)
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update araclar set arac_marka=@Vma,arac_model=@Vmo,uretim_yılı=@VY,yakit_tipi=@VEng,arac_renk=@VCo,arac_kilometre=@VMi,arac_turu=@VTy,rezerve=@VB,surucu=@Dr where arac_plaka=@VP", DB.baglanti());
                    cmd.Parameters.AddWithValue("@VP", LPlateTb.Text);
                    cmd.Parameters.AddWithValue("@Vma", MarkaCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Vmo", ModelTb.Text);
                    cmd.Parameters.AddWithValue("@VY", VYearCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VEng", EngTypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VCo", ColorTb.Text);
                    cmd.Parameters.AddWithValue("@VMi", MilleageTb.Text);
                    cmd.Parameters.AddWithValue("@VTy", TypeCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@VB", BookedCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Dr", DriverCb.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Aracınız Başarıyla Düzenlendi");
                    ShowAraclar();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            musteri Obj = new musteri();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            rezervasyon Obj = new rezervasyon();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
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
            this.Hide();
            Obj.Show();
        }
    }
}
