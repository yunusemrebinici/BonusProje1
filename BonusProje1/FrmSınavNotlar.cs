﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds=new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=EMRE\SQLEXPRESS01;Initial Catalog=BonusOkul;Integrated Security=True;");


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(TxtID.Text));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmOgretmen frm = new FrmOgretmen();
            frm.Show();
        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            ;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLDERSLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DERSAD";
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); 
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text= dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text= dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }
        int notid;
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            
           // string durum;
           
            sinav1 = Convert.ToInt32(TxtSınav1.Text);
            sinav2 = Convert.ToInt32(TxtSınav2.Text);
            sinav3 = Convert.ToInt32(TxtSınav3.Text);
            proje = Convert.ToInt32(TxtProje.Text);
            ortalama = (sinav1+sinav2+sinav3+proje)/4;
            TxtOrtalama.Text=ortalama.ToString();
            if (ortalama>=50)
            {
                TxtDurum.Text = "True";

            }
            else
            {
                TxtDurum.Text = "False";
            }




        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()),int.Parse(TxtID.Text),byte.Parse(TxtSınav1.Text),byte.Parse(TxtSınav2.Text), byte.Parse(TxtSınav3.Text), byte.Parse(TxtProje.Text), decimal.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text),notid);
        }
    }
}
