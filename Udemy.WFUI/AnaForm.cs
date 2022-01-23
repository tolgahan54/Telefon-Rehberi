using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Udemy.Entities;

namespace Udemy.WFUI
{
    public partial class AnaForm : Form
    {
        Udemy.BLL.BusinessLogicLayer BLL;
        public AnaForm()
        {
            InitializeComponent();
            BLL = new Udemy.BLL.BusinessLogicLayer();
        }

        private void btn_yeni_kayit_Click(object sender, EventArgs e)
        {
           int Sonuc = BLL.YeniKayit(Guid.NewGuid(), txt_isim.Text, txt_soyisim.Text, txt_telefonI.Text, txt_telefonII.Text, txt_telefonIII.Text, txt_adres.Text, txt_emailadres.Text, txt_website.Text, txt_aciklama.Text);

            if (Sonuc > 0)
            {
                MessageBox.Show("Kaydınız başarılı bir şekilde eklendi");
                Doldur();
            }
            else if (Sonuc == -100)
            {
                MessageBox.Show("Eksik parametre hatası. Lütfen Isim Soyisim TelefonI alanları doldurunuz");
            }
            else
            {
                MessageBox.Show("Kayıt Ekleme İşleminde Hata Oluştu");
            }
        }

        private void Doldur()
        {
            List<RehberKayit> RehberKayitlarim = BLL.RehberKayitlariGetir();
            if(RehberKayitlarim != null && RehberKayitlarim.Count>0)
            {
                lst_liste.DataSource = RehberKayitlarim;
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            Doldur();
        }

        private void lst_liste_DoubleClick(object sender, EventArgs e)
        {
            ListBox L = (ListBox)sender;
            RehberKayit SecilenDeger = (RehberKayit)L.SelectedItem;
            txt_isim.Text = SecilenDeger.Isim;
            txt_soyisim.Text = SecilenDeger.Soyisim;
            txt_telefonI.Text = SecilenDeger.TelefonI;
            txt_telefonII.Text = SecilenDeger.TelefonII;
            txt_telefonIII.Text = SecilenDeger.TelefonIII;
            txt_emailadres.Text = SecilenDeger.EmailAdres;
            txt_website.Text = SecilenDeger.Website;
            txt_adres.Text = SecilenDeger.Adres;
            txt_aciklama.Text = SecilenDeger.Aciklama;
            grpbox_kayit.Text = "Rehber Kayıt Güncelle";
        }
    }
}
