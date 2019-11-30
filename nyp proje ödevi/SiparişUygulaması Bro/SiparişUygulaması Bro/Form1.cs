using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SiparişUygulaması_Bro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();   
            txtMsifre.PasswordChar ='•'; //şifre girileceği textbox olduğu için gizleme
            txtMsifre.MaxLength = 5;
            txtKsifre.PasswordChar= '•';
            txtKsifre.MaxLength = 5;
        }

        bool CreditC = false, CashC = false, CheckC = false, pass = false, bilgi = false;
        bool K1 = false, K2 = false, K3 = false, M1 = false, M2 = false, M3 = false, M4 = false, M5 = false, M6 = false, M7 = false;
        string Müşteri, ÖncekiM;
        internal List<Order> orders = new List<Order>();
        Customer customer = new Customer();
        internal List<Item> itemsb = new List<Item>();
   






        private void Form1_Load(object sender, EventArgs e) //Form yüklenirken yapılan işlemler
        {
            pnKGirişi.Visible = false;
            pnMGirişi.Visible = false;
            pnMüşteriTakip.Visible = false;
            pnSiparişPaneli.Visible = false;
            pnAdmin.Visible = false;

            Center(pnGiriş);
        }

        private void btnKullanici_Click(object sender, EventArgs e) //menüde geri gitme butonu
        {
            
            pnGiriş.Visible = false;
            pnKGirişi.Visible = true;
            Center(pnKGirişi);
           
                
        }

        private void btnKgiris_Click(object sender, EventArgs e) //kullanıcı  girişi
        {
            K1 = LoginControlK1();
            K2 = LoginControlK2();
            K3 = LoginControlK3();
            pass = Password();
            if ((K1 == true || K2==true || K3==true)  && pass == true) //kullanıcı adı ve şifre kontrolu
            {
                Center(pnAdmin);
                pnKGirişi.Visible = false;
                pnAdmin.Visible = true;
                K1 = false;
                K2 = false;
                K3 = false;
                pass = false;
            }
            else
                MessageBox.Show("Hatalı Giriş","Error");
            
            
        }

        private void btnMusteri_Click(object sender, EventArgs e) //menüde geri gitme butonu
        {
            pnGiriş.Visible = false;
            pnMGirişi.Visible = true;
            Center(pnMGirişi);

           
                
        }

        private void btnMgiris_Click(object sender, EventArgs e) //Müşteri girişi
        {
            M1 = LoginControlM1();
            M2 = LoginControlM2();
            M3 = LoginControlM3();
            M4 = LoginControlM4();
            M5 = LoginControlM5();
            M6 = LoginControlM6();
            M7 = LoginControlM7();


            pass = Password();
            if ((M1 == true || M2==true || M3==true || M4==true || M5==true || M6==true || M7==true) && pass == true ) // müşteri adı ve şifre kontrolu
            {
                Müşteri = txtMusteri.Text;

                pnMGirişi.Visible = false;
                pnSiparişPaneli.Visible = true;

                Center(pnSiparişPaneli);

               
                M1 = false;
                M2 = false;
                M3 = false;
                M4 = false;
                M5 = false;
                M6 = false;
                M7 = false;
                pass = false;
            }
            else
                MessageBox.Show("Hatalı Giriş", "Error");




        }

        private void btnMusteriTakip_Click(object sender, EventArgs e) //menüde geri gitme butonu
        {
            Clear();
            Center(pnMüşteriTakip);
            pnAdmin.Visible = false;
            pnMüşteriTakip.Visible = true;
        }

        private void btnKGGeri_Click(object sender, EventArgs e) //menüde geri gitme butonu
        {
            pnGiriş.Visible = true;
            pnKGirişi.Visible = false;
            Center(pnGiriş);
        }

        private void btnEkle_Click(object sender, EventArgs e) //Ürünün eklenmesi
        {
            Item item = new Item();

            item.Name = txtUrunAd.Text;
            item.description = txtAciklama.Text;
            item.cost = Convert.ToInt32(txtFiyat.Text);
            item.ShippingWeight = txtAgirlik.Text;
            cmbSiparis.Items.Add(txtUrunAd.Text);
            cmbÜrün.Items.Add(txtUrunAd.Text);
            


            itemsb.Add(item);
            MessageBox.Show("Bir Ürün Eklediniz.");

           



        }

        private void btnMGGeri_Click(object sender, EventArgs e) //menüde geri gitme butonu
        {
            pnMGirişi.Visible = false;
            pnGiriş.Visible = true;
            Center(pnGiriş);
        }

        private void btnSgeri_Click(object sender, EventArgs e) //menüde geri gitme butonu
        {
            pnSiparişPaneli.Visible = false;
            pnGiriş.Visible = true;

            Center(pnGiriş);

           
        }

        private void btnMTgeri_Click(object sender, EventArgs e) //menüde geri gitme butonu
        {
            pnMüşteriTakip.Visible = false;
            pnAdmin.Visible = true;
            Center(pnAdmin);

            lblVerilenS.Visible = false;
            lblFiyati.Visible = false;
            lblDurum.Visible = false;
            lblGuncelleD.Visible = false;
            lblTarih.Visible = false;
            lblAdres.Visible = false;

            txtVerilenS.Visible = false;
            txtFiyati.Visible = false;
            txtDurum.Visible = false;
            txtAdress.Visible = false;
            txtTarihh.Visible = false;

            btnKargo.Visible = false;
            btnTeslim.Visible = false;

        }

        private void rdioKrediKarti_CheckedChanged(object sender, EventArgs e) //kredi kartı ödeme yolunun seçilmesi durumu
        {
            OdemeKontrol();
            sakla();
            CreditC = true;
            
            lblKNo.Visible = true;
            lbltip.Visible = true;
            lblSTarih.Visible = true;

            txtKrediKartiNum.Visible = true;
            cmbAy.Visible = true;
            cmbYil.Visible = true;
            cmbTip.Visible = true;
        }

        private void rdioNakit_CheckedChanged(object sender, EventArgs e) //nakit ödeme yolunun seçilmesi durumu
        {
            OdemeKontrol();
            sakla();
            CashC = true;
            lblNakit.Visible = true;
            txtNMiktar.Visible = true;
        }

        private void btnAGeri_Click(object sender, EventArgs e) //menüde geri ilerleme
        {
            Adminsakla();
            Clear();
            pnAdmin.Visible = false;
            pnGiriş.Visible = true;

            Center(pnGiriş);

     



        }

        private void rdioCek_CheckedChanged(object sender, EventArgs e) //çek ödeme yolunun seçilmesi durumu
        {
            OdemeKontrol();
            sakla();
            CheckC = true;
            lblCekAd.Visible = true;
            lblBankaID.Visible = true;

            txtCekAd.Visible = true;
            txtBankK.Visible = true;
        }

        private void btnUrunEkle_Click(object sender, EventArgs e) //admin panelinde ürün ekle butonu
        {
            Adminsakla();
            Clear();
            bilgi = false;
            lblAciklama.Visible = true;
            lblAgirlik.Visible = true;
            lblFiyat.Visible = true;
            lblUrun.Visible = true;

            txtUrunAd.Visible = true;
            txtFiyat.Visible = true;
            txtAgirlik.Visible = true;
            txtAciklama.Visible = true;

            btnEkle.Visible = true;
        }

        void sakla() //sipariş ekranındaki durumsal olayları gizleme
        {
            lblCekAd.Visible = false;
            lblBankaID.Visible = false;

            txtCekAd.Visible = false;
            txtNMiktar.Visible = false;

            lblKNo.Visible = false;
            lbltip.Visible = false;
            lblSTarih.Visible = false;

            txtKrediKartiNum.Visible = false;
            cmbAy.Visible = false;
            cmbYil.Visible = false;

            lblNakit.Visible = false;
            txtNMiktar.Visible = false;
            txtBankK.Visible = false;
            cmbTip.Visible = false;
        }

        void OdemeKontrol() //diğer alışveriş yöntemlerinin ilk önce false olarak ayarlanması
        {
            CashC = false;
            CheckC = false;
            CreditC = false;
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            Adminsakla();
            Clear();
            bilgi = false;
            lblGuncelle.Visible = true;
            lblGuncelle.Text = "Güncellenecek Ürün";
            cmbÜrün.Visible = true;

            lblAciklama.Visible = true;
            lblAgirlik.Visible = true;
            lblFiyat.Visible = true;



            txtFiyat.Visible = true;
            txtAgirlik.Visible = true;
            txtAciklama.Visible = true;

            

            btnGuncelle.Visible = true;
        }

        private void cmbSiparis_SelectedIndexChanged(object sender, EventArgs e) 
        {
            

            foreach (Item a in itemsb)
            {
                if (a.Name == cmbSiparis.Text)
                {
                    lblFiyad.Text = "Fiyatı:" + a.cost;
                    lblagirr.Text = "Ağırlığı:" + a.ShippingWeight;
                    lblAcikla.Text = "Açıklama:" + a.description;
                    lblFiyad.Visible = true;
                    lblagirr.Visible = true;
                    lblAcikla.Visible = true;

                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e) //ürünün sistemde güncellenmesi
        {
            foreach (Item a in itemsb)
            {
                if (a.Name == cmbÜrün.Text)
                {
                    a.cost = Convert.ToInt32(txtFiyat.Text);
                    a.description = txtAciklama.Text;
                    a.ShippingWeight = txtAgirlik.Text;

                }
            }
            MessageBox.Show("Başarıyla Güncellendi");

        }

        private void btnCikar_Click(object sender, EventArgs e) //ürünün sistemden silinmesi
        {
            
            cmbSiparis.Items.Remove(cmbÜrün.Text);
            cmbÜrün.Items.Remove(cmbÜrün.Text);
            
            

            MessageBox.Show("Ürün Çıkarıldı");


        }

        private void cmbSiparis_SelectedIndexChanged_1(object sender, EventArgs e)  //sipariş verirken seçilen ürün bilgilerinin gözükmesi
        {
            foreach(Item a in itemsb)
            {
                if(cmbSiparis.Text==a.Name)
                {
                    lblFiyad.Text = "Fiyat:" + a.cost+" TL";
                    lblAcikla.Text ="Açıklama:" +a.description;
                    lblagirr.Text = "Ağırlık:" + a.ShippingWeight;

                    lblagirr.Visible = true;
                    lblFiyad.Visible = true;
                    lblAcikla.Visible = true;
                    lblKargo.Visible = true;
                }
            }
        }

        private void cmbMusteri_SelectedIndexChanged(object sender, EventArgs e) // müşteri takipte müşteri seçildiğinde bütün bilgilerinin gözükmesi
        {
           Order order = new Order();


            int Fiyat =0;

        
            foreach(Order a in orders)
            {

                if (a.customer.name == cmbMusteri.Text)
                {
                    Fiyat += a.ıtem.cost + 5;
                    txtDurum.Text = a.status;
                    txtTarihh.Text = a.date;
                    txtAdress.Text = a.customer.address;

                }                                         
            }
            txtVerilenS.Text = OrderList();
            txtFiyati.Text = Fiyat.ToString()+" TL";

            lblVerilenS.Visible = true;
            lblFiyati.Visible = true;
            lblDurum.Visible = true;
            lblGuncelleD.Visible = true;
            lblTarih.Visible = true;
            lblAdres.Visible = true;

           
            txtVerilenS.Visible = true;
            txtFiyati.Visible = true;
            txtDurum.Visible = true;
            txtAdress.Visible = true;
            txtTarihh.Visible = true;

            btnKargo.Visible = true;
            btnTeslim.Visible = true;
        }

        private void cmbÜrün_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnKargo_Click(object sender, EventArgs e) //sipariş durumu değiştirme
        {
            foreach (Order a in orders)
            {
                if (cmbMusteri.Text == a.customer.name)
                {
                    a.status = "Kargoda";
                    txtDurum.Text = a.status;
                   
                }
            }
            
                       

        }

        private void btnTeslim_Click(object sender, EventArgs e) //sipariş durumu değiştirme
        {
            foreach (Order a in orders)
            {
                if (cmbMusteri.Text == a.customer.name)
                {
                    a.status = "Teslim Edildi";
                    txtDurum.Text = a.status;
                    
                }
            }
           
        }

        private void btnSiparisVer_Click(object sender, EventArgs e) //siparişın alınması işlemi
        {
            Order order = new Order();
            
            if(CreditC==true) //çoklu ödeme yöntemlerine göre ayrılıyor
            {
               
                foreach (Item a in itemsb)
                {    
                    if (cmbSiparis.Text == a.Name)
                    {
                        order.ıtem.Name = a.Name;
                        order.ıtem.cost = a.cost;
                        order.ıtem.description = a.description;
                        order.ıtem.ShippingWeight = a.ShippingWeight;
                        order.credit.amount = a.cost;
                    }
                }

                order.status = "Hazırlanıyor";                     
                order.date = DateTime.Now.ToString();

                order.credit.number = txtKrediKartiNum.Text;
                order.credit.type= cmbTip.Text;
                order.credit.expDate= cmbYil.Text + "." + cmbAy.Text;
              
                order.detail.quantity += 1;
                order.detail.taxStatus = order.calcTax(order.calcTotal());

                order.customer.address = txtAdresAl.Text;
                order.customer.name = Müşteri;

                orders.Add(order);


                if (ÖncekiM != Müşteri) 
                cmbMusteri.Items.Add(Müşteri);

                ÖncekiM = Müşteri;

                MessageBox.Show("Siparişiniz Alındı");
                
            }

            if(CheckC==true) //çoklu ödeme yöntemlerine göre ayrılıyor
            {
                order.status = "Hazırlanıyor";
                order.date= DateTime.Now.ToString();
        
                order.check.bankID = txtBankK.Text;
                order.check.name= txtCekAd.Text;

                foreach (Item a in itemsb)
                {
                    if (cmbSiparis.Text == a.Name)
                    {
                        order.ıtem.Name = a.Name;
                        order.ıtem.cost = a.cost;
                        order.ıtem.description = a.description;
                        order.ıtem.ShippingWeight = a.ShippingWeight;
                        order.check.amount = a.cost;
                    }
                }

                order.detail.quantity += 1;
                order.detail.taxStatus = order.calcTax(order.calcTotal());

                order.customer.address = txtAdresAl.Text;
                order.customer.name =Müşteri;

                orders.Add(order);

                

                if (ÖncekiM != Müşteri) 
                cmbMusteri.Items.Add(Müşteri);

                ÖncekiM = Müşteri;

                MessageBox.Show("Siparişiniz Alındı");
            }

            if(CashC==true) //çoklu ödeme yöntemlerine göre ayrılıyor
            {
                int f = 0;

                foreach (Item a in itemsb)
                {
                    if (cmbSiparis.Text == a.Name)                                          
                        f = a.cost+5;                                         
                }
                order.cash.cashTendered = Convert.ToInt32(txtNMiktar.Text);
                if (order.cash.cashTendered<f)
                {
                    MessageBox.Show("Vereceğiniz miktar Ürünün Fiyatından ve kargo fiyatından az olamaz");
                    
                }
                else
                {
                    order.status = "Hazırlanıyor";
                    order.date = DateTime.Now.ToString();


                    

                    foreach (Item a in itemsb)
                    {
                        if (cmbSiparis.Text == a.Name)
                        {
                            order.ıtem.Name = a.Name;
                            order.ıtem.cost = a.cost;
                            order.ıtem.description = a.description;
                            order.ıtem.ShippingWeight = a.ShippingWeight;
                            order.cash.amount = a.cost;

                        }
                    }

                    order.detail.quantity += 1;
                    order.detail.taxStatus = order.calcTax(order.calcTotal());

                    order.customer.address = txtAdresAl.Text;
                    order.customer.name = Müşteri;

                    orders.Add(order);
          

                    if (ÖncekiM != Müşteri)
                        cmbMusteri.Items.Add(Müşteri);

                    ÖncekiM = Müşteri;

                    MessageBox.Show("Siparişiniz Alındı");
                }

                

            }
        }

        int ParaBilgi()
        {
            int para=0;
            foreach(Item a in itemsb)
            {
                if(a.Name==cmbSiparis.Text)
                {
                    para = a.cost; 
                }
            }
            return para;
        }

        private void btnUrunCikar_Click(object sender, EventArgs e) //müşteri adı bilgileri kontrol
        {
            Adminsakla();
            Clear();
            bilgi = false;
            lblGuncelle.Text = "Çıkarılacak Ürün";
            lblGuncelle.Visible = true;
            btnCikar.Visible = true;
            cmbÜrün.Visible = true;
            cmbÜrün.Visible = true;


        }

        void Adminsakla() // tüm admin panelindeki butonlarındaki geçiş sırasında bütün her şeyin saklanması işlemi
        {
            lblAciklama.Visible = false;
            lblAgirlik.Visible = false;
            lblFiyat.Visible = false;
            lblUrun.Visible = false;
            lblGuncelle.Visible = false;

            txtUrunAd.Visible = false;
            txtFiyat.Visible = false;
            txtAgirlik.Visible = false;
            txtAciklama.Visible = false;

            cmbÜrün.Visible = false;

            btnEkle.Visible = false;
            btnGuncelle.Visible = false;
            btnCikar.Visible = false;
        }

        public string OrderList() //Müşterinin verdiği siparişlerin topluca stringe atanması
        {
            string strTemp = "";
            foreach (Order a in orders)
            {
               
                if (a.customer.name==cmbMusteri.Text)
                {
                        strTemp += "Ürün:" + a.ıtem.Name + Environment.NewLine + "Açıklama:" + a.ıtem.description + Environment.NewLine + "Ağırlık:" + a.ıtem.ShippingWeight + Environment.NewLine + "--------------------------" + Environment.NewLine;            
                }

            }
            return strTemp;
        }

        private void btnGörüntüle_Click(object sender, EventArgs e) //admin kontrol butonu
        {
            Adminsakla();
            Clear();
            bilgi = true;
            

            lblGuncelle.Visible = true;
            lblUrun.Visible = true;
            lblFiyat.Visible = true;
            lblAciklama.Visible = true;
            lblAgirlik.Visible = true;

            lblGuncelle.Text = "Bilgisi Alınacak Ürün";


            cmbÜrün.Visible = true;

            txtUrunAd.Visible = true;
            txtFiyat.Visible = true;
            txtAciklama.Visible = true;
            txtAgirlik.Visible = true;
        
        }

        private void cmbÜrün_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(bilgi==true)   //sadece "ÜRÜN BİLGİ GÖRÜNTÜLE" butonuna tıklandığında çalışır
            {
                foreach (Item a in itemsb)      //itemsb listesindeki bütün itemleri tarar
                {
                    if (cmbÜrün.Text == a.Name)  //comboxta seçilen item listedeki herhangi bir itemin adıyla aynı olduğunda onun bilgilerini atar
                    {
                        txtUrunAd.Text = a.Name;
                        txtFiyat.Text = a.cost.ToString();
                        txtAciklama.Text = a.description;
                        txtAgirlik.Text = a.ShippingWeight;

                    }
                }
            }
           
        }

        void Clear() //admin kontrol panelinde gezerken textboxları temizler
        {
            txtUrunAd.Clear();
            txtFiyat.Clear();
            txtAciklama.Clear();
            txtAgirlik.Clear();

        }

        bool LoginControlK1()  //kullanıcı adı bilgileri kontrol
        {
            using (StreamReader Kullanici1 = new StreamReader("Kullanıcı1.txt"))
            {
                string line = Kullanici1.ReadLine();
         
                
                    if (line == txtKullanici.Text)
                        return true;
                    else
                        return false;

            }
        }

        bool LoginControlK2() //kullanıcı adı bilgileri kontrol
        {
            using (StreamReader Kullanici2 = new StreamReader("Kullanıcı2.txt"))
            {
                string line = Kullanici2.ReadLine();


                if (line == txtKullanici.Text)
                    return true;
                else
                    return false;

            }
        }
        bool LoginControlK3() //kullanıcı adı bilgileri kontrol
        { 
            using (StreamReader Kullanici3 = new StreamReader("Kullanıcı3.txt"))
            {
                string line = Kullanici3.ReadLine();


                if (line == txtKullanici.Text)
                    return true;
                else
                    return false;

            }
        }


        bool Password() //Şifre bilgileri kontrol
        {
            using (StreamReader P = new StreamReader("şifre.txt"))
            {
                string line = P.ReadLine();

                if (line == txtKsifre.Text || line == txtMsifre.Text)
                    return true;
                else
                    return false;
            }
        }

        bool LoginControlM1() //müşteri adı bilgileri kontrol
        {
            using (StreamReader  Musteri1 = new StreamReader("Müşteri1.txt"))
            {
                string line = Musteri1.ReadLine();

                if (line == txtMusteri.Text)
                    return true;
                else
                    return false;

            }
        }
        bool LoginControlM2() //müşteri adı bilgileri kontrol
        {
            using (StreamReader Musteri2 = new StreamReader("Müşteri2.txt"))
            {
                string line = Musteri2.ReadLine();

                if (line == txtMusteri.Text)
                    return true;
                else
                    return false;

            }
        }
        bool LoginControlM3() //müşteri adı bilgileri kontrol
        {
            using (StreamReader Musteri3 = new StreamReader("Müşteri3.txt"))
            {
                string line = Musteri3.ReadLine();

                if (line == txtMusteri.Text)
                    return true;
                else
                    return false;

            }
        }
        bool LoginControlM4() //müşteri adı bilgileri kontrol
        {
            using (StreamReader Musteri4 = new StreamReader("Müşteri4.txt"))
            {
                string line = Musteri4.ReadLine();

                if (line == txtMusteri.Text)
                    return true;
                else
                    return false;

            }
        }
        bool LoginControlM5() //müşteri adı bilgileri kontrol
        {
            using (StreamReader Musteri5 = new StreamReader("Müşteri5.txt"))
            {
                string line = Musteri5.ReadLine();

                if (line == txtMusteri.Text)
                    return true;
                else
                    return false;

            }
        }
        bool LoginControlM6() //müşteri adı bilgileri kontrol
        {
            using (StreamReader Musteri6 = new StreamReader("Müşteri6.txt"))
            {
                string line = Musteri6.ReadLine();

                if (line == txtMusteri.Text)
                    return true;
                else
                    return false;

            }
        }
        bool LoginControlM7() //müşteri adı bilgileri kontrol
        {
            using (StreamReader Musteri7 = new StreamReader("Müşteri7.txt"))
            {
                string line = Musteri7.ReadLine();

                if (line == txtMusteri.Text)
                    return true;
                else
                    return false;

            }
        }

        void Center(Panel a) //panelden panele geçerken paneli formun ortasına atar
        {
            a.Location = new Point(
            this.ClientSize.Width / 2 - a.Size.Width / 2,
            this.ClientSize.Height / 2 - a.Size.Height / 2);
            a.Anchor = AnchorStyles.None;
        }
    }
}
