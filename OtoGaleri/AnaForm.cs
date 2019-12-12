using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoGaleri
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }



        private void cmbMarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbMarka.Text)
            {
                case "VOLKSWAGEN":
                    cmbModel.Items.Add("JETTA");
                    cmbModel.Items.Add("PASSAT");
                    cmbModel.Items.Add("CC");
                    break;
                case "AUDİ":
                    cmbModel.Items.Add("A7");
                    cmbModel.Items.Add("Q7");
                    cmbModel.Items.Add("R8");
                    break;
                case "BMW":
                    cmbModel.Items.Add("M6 COUPE");
                    cmbModel.Items.Add("X6 ");
                    cmbModel.Items.Add("5.25");
                    break;
                case "MERCEDES":
                    cmbModel.Items.Add("200 AMG");
                    cmbModel.Items.Add("E 250");
                    cmbModel.Items.Add("CLA 200");
                    break;
                case "RENAULT":
                    cmbModel.Items.Add("CLIO");
                    cmbModel.Items.Add("LAGUNA");
                    cmbModel.Items.Add("SYMBOL");
                    break;
                case "HYUNDAİ":
                    cmbModel.Items.Add("ACCENT");
                    cmbModel.Items.Add("i 30");
                    cmbModel.Items.Add("iX 35");
                    cmbModel.Items.Add("i 20");
                    break;
                case "HONDA":
                    cmbModel.Items.Add("CIVIC");
                    cmbModel.Items.Add("CITY");
                    cmbModel.Items.Add("CR-V");
                    break;

                default:
                    break;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.UseItemStyleForSubItems = false; // LVİ Stillerini müdahale eder.
            lvi.Text = cmbMarka.Text;
            lvi.SubItems.Add(cmbModel.Text);
            lvi.SubItems.Add(cmbYakit.Text);
            lvi.SubItems.Add(cmbKasa.Text);
            lvi.SubItems.Add(cmbVites.Text);
            lvi.SubItems.Add(cmbMotor.Text);
            lvi.SubItems.Add(cmbRenk.Text);
            lvi.SubItems.Add(dateYili.Text);

            listView1.Items.Add(lvi); // Son aşamada ekleme gerçekleştirilir.

            dateYili.Value = DateTime.Now; // TARİH TEKLİ DEFAULT

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;  //  BÜTÜN CMBLERİ VALUE 0 LAR.
                }

                //else if (ctrl is TextBox)
                //{
                //    ((TextBox)ctrl).Text = string.Empty;   //  BÜTÜN TEXTBOXLARI TEMİZLER
                //}
                else if (ctrl is DateTimePicker)
                {
                    ((DateTimePicker)ctrl).Value = DateTime.Now;  // TARİH ÇOKLU DEFAULT 
                }
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
        ListViewItem secilen;
        private void btnDüzenle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen kayıt düzenlemek için seçim yapınız.");
                return;
            }

            secilen = listView1.SelectedItems[0];
            cmbMarka.Text = secilen.Text;
            cmbModel.Text = secilen.SubItems[1].Text;
            cmbYakit.Text = secilen.SubItems[2].Text;
            cmbKasa.Text = secilen.SubItems[3].Text;
            cmbVites.Text = secilen.SubItems[4].Text;
            cmbMotor.Text = secilen.SubItems[5].Text;
            cmbRenk.Text = secilen.SubItems[6].Text;
            //dateYili.Value = Convert.ToDateTime(secilen.SubItems[7].Text);
            dateYili.Text = secilen.SubItems[7].Text;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            secilen.SubItems[0].Text = cmbMarka.Text;
            secilen.SubItems[1].Text = cmbModel.Text;
            secilen.SubItems[2].Text = cmbYakit.Text;
            secilen.SubItems[3].Text = cmbKasa.Text;
            secilen.SubItems[4].Text = cmbVites.Text;
            secilen.SubItems[5].Text = cmbMotor.Text;
            cmbRenk.Text = secilen.SubItems[6].Text;
            secilen.SubItems[7].Text = dateYili.Text;
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen kayıt düzenlemek için seçim yapınız.");
                return;
            }

            secilen = listView1.SelectedItems[0];
            cmbMarka.Text = secilen.Text;
            cmbModel.Text = secilen.SubItems[1].Text;
            cmbYakit.Text = secilen.SubItems[2].Text;
            cmbKasa.Text = secilen.SubItems[3].Text;
            cmbVites.Text = secilen.SubItems[4].Text;
            cmbMotor.Text = secilen.SubItems[5].Text;
            cmbRenk.Text = secilen.SubItems[6].Text;
            //dateYili.Value = Convert.ToDateTime(secilen.SubItems[7].Text);
            dateYili.Text = secilen.SubItems[7].Text;
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                }
            }
        }


    }
}
