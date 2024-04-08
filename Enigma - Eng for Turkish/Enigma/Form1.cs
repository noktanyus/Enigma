using System;  // System ad alanýný kullanmak için gerekli
using System.Text;  // Metin iþlemleri için gerekli System.Text kütüphanesini kullanmak için
using System.Windows.Forms;  // Windows uygulamalarý için gerekli System.Windows.Forms kütüphanesini kullanmak için

namespace Enigma  // Enigma adýnda bir namespace oluþturulmasý
{
    public partial class Form1 : Form  // Form1 adýnda kýsmi bir sýnýf oluþturulmasý ve Form sýnýfýndan türetilmesi
    {
        // Rotorlar dizisi, yansýtýcý ve alfabe tanýmlamalarý
        private string[] rotors = {  // Rotorlar için dizi oluþturulmasý ve tanýmlanmasý
            "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
            "AJDKSIRUXBLHWTMCQGZNPYFVOE",
            "BDFHJLCPRTXVZNYEIWGAKMUSQO",
            "ESOVPZJAYQUIRHXLNFTGKDCMWB",
            "VZBRGITYUPSDNHLXAWMJQOFECK",
            "QWERTYUIOPASDFGHJKLZXCVBNM"
        };
        private string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT";  // Yansýtýcý rotorun tanýmlanmasý
        private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";  // Alfabe tanýmlanmasý

        // Form1 kurucu metodu
        public Form1()
        {
            InitializeComponent();  // Form bileþenlerinin baþlatýlmasý
        }

        // Buton1_Click olayý
        private void button1_Click(object sender, EventArgs e)
        {
            // Rastgele rotor seçimi ve pozisyon belirleme
            int rotorSayisi = rotors.Length;  // Rotor sayýsýnýn alýnmasý
            Random rastgele = new Random();  // Rastgele sayý üretecek nesnenin oluþturulmasý

            // Rastgele rotor seçimi ve pozisyon belirleme
            int rastgeleRotorIndeksi = rastgele.Next(rotorSayisi);  // Rastgele bir rotorun seçimi
            int rastgeleRotorIndeksi2 = rastgele.Next(rotorSayisi);  // Ýkinci rastgele bir rotorun seçimi
            int rastgeleRotorIndeksi3 = rastgele.Next(rotorSayisi);  // Üçüncü rastgele bir rotorun seçimi
            int pozisyon1 = rastgele.Next(26);  // Birinci rotorun pozisyonunun belirlenmesi
            int pozisyon2 = rastgele.Next(26);  // Ýkinci rotorun pozisyonunun belirlenmesi
            int pozisyon3 = rastgele.Next(26);  // Üçüncü rotorun pozisyonunun belirlenmesi

            // Sonuç metninin oluþturulmasý ve TextBox'lara yazdýrýlmasý
            string sonuc = $"{rastgeleRotorIndeksi + 1}.{pozisyon1}";  // Sonucun oluþturulmasý
            string sonuc2 = $"{rastgeleRotorIndeksi2 + 1}.{pozisyon2}";  // Ýkinci sonucun oluþturulmasý
            string sonuc3 = $"{rastgeleRotorIndeksi3 + 1}.{pozisyon3}";  // Üçüncü sonucun oluþturulmasý
            textBox1.Text = sonuc;  // Birinci sonucun TextBox1'e yazdýrýlmasý
            textBox2.Text = sonuc2;  // Ýkinci sonucun TextBox2'ye yazdýrýlmasý
            textBox3.Text = sonuc3;  // Üçüncü sonucun TextBox3'e yazdýrýlmasý
        }


        private string TurkceToIngilizce(string metin)
        {
            // Türkçe karakterleri Ýngilizce karakterlere dönüþtürmek için bir sözlük oluþturulmasý
            Dictionary<char, char> cevirmeTablosu = new Dictionary<char, char>()
    {
        {'Ö', 'O'}, {'ö', 'o'},  // Büyük ve küçük "Ö" harflerinin "O" ve "o" harflerine dönüþümü
        {'Ü', 'U'}, {'ü', 'u'},  // Büyük ve küçük "Ü" harflerinin "U" ve "u" harflerine dönüþümü
        {'Ý', 'I'}, {'i', 'I'},  // Büyük "Ý" harfinin "I" ve küçük "i" harfinin "I" harfine dönüþümü
        {'Ð', 'G'}, {'ð', 'g'},  // Büyük ve küçük "Ð" harflerinin "G" ve "g" harflerine dönüþümü
        {'Ç', 'C'}, {'ç', 'c'},  // Büyük ve küçük "Ç" harflerinin "C" ve "c" harflerine dönüþümü
        {'Þ', 'S'}, {'þ', 's'}   // Büyük ve küçük "Þ" harflerinin "S" ve "s" harflerine dönüþümü
    };

            // Metindeki Türkçe karakterlerin Ýngilizce karakterlere dönüþtürülmesi
            StringBuilder yeniMetin = new StringBuilder();  // Dönüþtürülen metni depolamak için bir StringBuilder nesnesi oluþturulmasý
            foreach (char c in metin)  // Giriþ metnindeki her bir karakter için döngü
            {
                // Eðer karakter çevirme tablosunda varsa, Ýngilizce karþýlýðýný al
                if (cevirmeTablosu.ContainsKey(c))  // Karakterin çevirme tablosunda olup olmadýðýnýn kontrolü
                {
                    yeniMetin.Append(cevirmeTablosu[c]);  // Türkçe karakterin Ýngilizce karþýlýðýný eklemek
                }
                else
                {
                    yeniMetin.Append(c);  // Eðer karakter çevirme tablosunda yoksa, karakteri olduðu gibi eklemek
                }
            }

            return yeniMetin.ToString();  // Dönüþtürülen metnin dizeye dönüþtürülerek döndürülmesi
        }


        // Buton2_Click olayý
        private void button2_Click(object sender, EventArgs e)
        {
            // Giriþ metni alýnmasý
            string metin = TurkceToIngilizce(richTextBox1.Text);

            // Rotor pozisyonlarýnýn alýnmasý
            string[] pozisyonlar = { textBox1.Text, textBox2.Text, textBox3.Text };  // Rotor pozisyonlarýnýn alýnmasý
            int rotor1Poz = 0, rotor2Poz = 0, rotor3Poz = 0;  // Rotor pozisyonlarý için deðiþkenlerin tanýmlanmasý

            // Rotor pozisyonlarýnýn iþlenmesi
            for (int i = 0; i < pozisyonlar.Length; i++)  // Her bir pozisyonun iþlenmesi
            {
                string[] parcalar = pozisyonlar[i].Split('.');  // Pozisyon parçalarýnýn ayrýþtýrýlmasý
                if (parcalar.Length == 2 && int.TryParse(parcalar[0], out int rotorNumarasi) && int.TryParse(parcalar[1], out int pozisyon))
                {
                    rotorNumarasi = Math.Max(1, Math.Min(rotors.Length, rotorNumarasi)) - 1;  // Rotor numarasýnýn sýnýrlandýrýlmasý
                    pozisyon = (pozisyon % 26 + 26) % 26;  // Pozisyonun sýnýrlandýrýlmasý
                    if (i == 0)
                        rotor1Poz = pozisyon;  // Birinci rotorun pozisyonunun atanmasý
                    else if (i == 1)
                        rotor2Poz = pozisyon;  // Ýkinci rotorun pozisyonunun atanmasý
                    else
                        rotor3Poz = pozisyon;  // Üçüncü rotorun pozisyonunun atanmasý
                }
                else
                {
                    MessageBox.Show("Hatalý rotör pozisyonu: " + pozisyonlar[i]);  // Hata mesajýnýn gösterilmesi
                    return;  // Metodun sonlandýrýlmasý
                }
            }

            // Metnin þifrelenmesi ve sonucun richTextBox2'ye eklenmesi
            richTextBox2.Text = Sifrele(metin, rotor1Poz, rotor2Poz, rotor3Poz);  // Metnin þifrelenmesi ve sonucun richTextBox2'ye yazdýrýlmasý
        }

        // Metnin þifrelenmesi
        private string Sifrele(string metin, int rotor1Poz, int rotor2Poz, int rotor3Poz)
        {
            StringBuilder sonuc = new StringBuilder();  // Sonuç metni için bir StringBuilder nesnesinin oluþturulmasý

            foreach (char c in metin.ToUpper())  // Giriþ metninin her bir karakteri için döngü
            {
                if (char.IsLetter(c))  // Karakterin bir harf olup olmadýðýnýn kontrolü
                {
                    char karakter = char.ToUpper(c);  // Karakterin büyük harfe dönüþtürülmesi

                    rotor1Poz = (rotor1Poz + 1) % 26;  // Rotor 1 pozisyonunun güncellenmesi
                    if (rotor1Poz == 0)  // Rotor 1 pozisyonunun sýfýra eþit olup olmadýðýnýn kontrolü
                    {
                        rotor2Poz = (rotor2Poz + 1) % 26;  // Rotor 2 pozisyonunun güncellenmesi
                        if (rotor2Poz == 0)  // Rotor 2 pozisyonunun sýfýra eþit olup olmadýðýnýn kontrolü
                        {
                            rotor3Poz = (rotor3Poz + 1) % 26;  // Rotor 3 pozisyonunun güncellenmesi
                        }
                    }

                    char rotor1Karakter = rotors[0][(alphabet.IndexOf(c) + rotor1Poz) % 26];  // Rotor 1 üzerindeki harfin þifrelenmesi
                    char rotor2Karakter = rotors[1][(alphabet.IndexOf(rotor1Karakter) + rotor2Poz) % 26];  // Rotor 2 üzerindeki harfin þifrelenmesi
                    char rotor3Karakter = rotors[2][(alphabet.IndexOf(rotor2Karakter) + rotor3Poz) % 26];  // Rotor 3 üzerindeki harfin þifrelenmesi
                    char yansiticiKarakter = reflector[alphabet.IndexOf(rotor3Karakter)];  // Yansýtýcý üzerindeki harfin þifrelenmesi
                    char rotor3GeriKarakter = alphabet[(rotors[2].IndexOf(yansiticiKarakter) + 26 - rotor3Poz) % 26];  // Rotor 3 geri dönüþ iþlemi
                    char rotor2GeriKarakter = alphabet[(rotors[1].IndexOf(rotor3GeriKarakter) + 26 - rotor2Poz) % 26];  // Rotor 2 geri dönüþ iþlemi
                    char rotor1GeriKarakter = alphabet[(rotors[0].IndexOf(rotor2GeriKarakter) + 26 - rotor1Poz) % 26];  // Rotor 1 geri dönüþ iþlemi
                    sonuc.Append(rotor1GeriKarakter);  // Sonucun son karakterin eklenmesi
                }
                else
                {
                    sonuc.Append(c);  // Karakterin direk olarak sonuca eklenmesi
                }
            }

            return sonuc.ToString();  // Sonucun döndürülmesi
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendiðinde yapýlacak iþlemler buraya yazýlabilir.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TextBox1'in metni deðiþtiðinde yapýlacak iþlemler buraya yazýlabilir.
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // TextBox2'nin metni deðiþtiðinde yapýlacak iþlemler buraya yazýlabilir.
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // TextBox3'ün metni deðiþtiðinde yapýlacak iþlemler buraya yazýlabilir.
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // RichTextBox1'in metni deðiþtiðinde yapýlacak iþlemler buraya yazýlabilir.
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            // RichTextBox2'nin metni deðiþtiðinde yapýlacak iþlemler buraya yazýlabilir.
        }

    }
}
