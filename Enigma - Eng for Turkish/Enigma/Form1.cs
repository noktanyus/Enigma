using System;  // System ad alan�n� kullanmak i�in gerekli
using System.Text;  // Metin i�lemleri i�in gerekli System.Text k�t�phanesini kullanmak i�in
using System.Windows.Forms;  // Windows uygulamalar� i�in gerekli System.Windows.Forms k�t�phanesini kullanmak i�in

namespace Enigma  // Enigma ad�nda bir namespace olu�turulmas�
{
    public partial class Form1 : Form  // Form1 ad�nda k�smi bir s�n�f olu�turulmas� ve Form s�n�f�ndan t�retilmesi
    {
        // Rotorlar dizisi, yans�t�c� ve alfabe tan�mlamalar�
        private string[] rotors = {  // Rotorlar i�in dizi olu�turulmas� ve tan�mlanmas�
            "EKMFLGDQVZNTOWYHXUSPAIBRCJ",
            "AJDKSIRUXBLHWTMCQGZNPYFVOE",
            "BDFHJLCPRTXVZNYEIWGAKMUSQO",
            "ESOVPZJAYQUIRHXLNFTGKDCMWB",
            "VZBRGITYUPSDNHLXAWMJQOFECK",
            "QWERTYUIOPASDFGHJKLZXCVBNM"
        };
        private string reflector = "YRUHQSLDPXNGOKMIEBFZCWVJAT";  // Yans�t�c� rotorun tan�mlanmas�
        private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";  // Alfabe tan�mlanmas�

        // Form1 kurucu metodu
        public Form1()
        {
            InitializeComponent();  // Form bile�enlerinin ba�lat�lmas�
        }

        // Buton1_Click olay�
        private void button1_Click(object sender, EventArgs e)
        {
            // Rastgele rotor se�imi ve pozisyon belirleme
            int rotorSayisi = rotors.Length;  // Rotor say�s�n�n al�nmas�
            Random rastgele = new Random();  // Rastgele say� �retecek nesnenin olu�turulmas�

            // Rastgele rotor se�imi ve pozisyon belirleme
            int rastgeleRotorIndeksi = rastgele.Next(rotorSayisi);  // Rastgele bir rotorun se�imi
            int rastgeleRotorIndeksi2 = rastgele.Next(rotorSayisi);  // �kinci rastgele bir rotorun se�imi
            int rastgeleRotorIndeksi3 = rastgele.Next(rotorSayisi);  // ���nc� rastgele bir rotorun se�imi
            int pozisyon1 = rastgele.Next(26);  // Birinci rotorun pozisyonunun belirlenmesi
            int pozisyon2 = rastgele.Next(26);  // �kinci rotorun pozisyonunun belirlenmesi
            int pozisyon3 = rastgele.Next(26);  // ���nc� rotorun pozisyonunun belirlenmesi

            // Sonu� metninin olu�turulmas� ve TextBox'lara yazd�r�lmas�
            string sonuc = $"{rastgeleRotorIndeksi + 1}.{pozisyon1}";  // Sonucun olu�turulmas�
            string sonuc2 = $"{rastgeleRotorIndeksi2 + 1}.{pozisyon2}";  // �kinci sonucun olu�turulmas�
            string sonuc3 = $"{rastgeleRotorIndeksi3 + 1}.{pozisyon3}";  // ���nc� sonucun olu�turulmas�
            textBox1.Text = sonuc;  // Birinci sonucun TextBox1'e yazd�r�lmas�
            textBox2.Text = sonuc2;  // �kinci sonucun TextBox2'ye yazd�r�lmas�
            textBox3.Text = sonuc3;  // ���nc� sonucun TextBox3'e yazd�r�lmas�
        }


        private string TurkceToIngilizce(string metin)
        {
            // T�rk�e karakterleri �ngilizce karakterlere d�n��t�rmek i�in bir s�zl�k olu�turulmas�
            Dictionary<char, char> cevirmeTablosu = new Dictionary<char, char>()
    {
        {'�', 'O'}, {'�', 'o'},  // B�y�k ve k���k "�" harflerinin "O" ve "o" harflerine d�n���m�
        {'�', 'U'}, {'�', 'u'},  // B�y�k ve k���k "�" harflerinin "U" ve "u" harflerine d�n���m�
        {'�', 'I'}, {'i', 'I'},  // B�y�k "�" harfinin "I" ve k���k "i" harfinin "I" harfine d�n���m�
        {'�', 'G'}, {'�', 'g'},  // B�y�k ve k���k "�" harflerinin "G" ve "g" harflerine d�n���m�
        {'�', 'C'}, {'�', 'c'},  // B�y�k ve k���k "�" harflerinin "C" ve "c" harflerine d�n���m�
        {'�', 'S'}, {'�', 's'}   // B�y�k ve k���k "�" harflerinin "S" ve "s" harflerine d�n���m�
    };

            // Metindeki T�rk�e karakterlerin �ngilizce karakterlere d�n��t�r�lmesi
            StringBuilder yeniMetin = new StringBuilder();  // D�n��t�r�len metni depolamak i�in bir StringBuilder nesnesi olu�turulmas�
            foreach (char c in metin)  // Giri� metnindeki her bir karakter i�in d�ng�
            {
                // E�er karakter �evirme tablosunda varsa, �ngilizce kar��l���n� al
                if (cevirmeTablosu.ContainsKey(c))  // Karakterin �evirme tablosunda olup olmad���n�n kontrol�
                {
                    yeniMetin.Append(cevirmeTablosu[c]);  // T�rk�e karakterin �ngilizce kar��l���n� eklemek
                }
                else
                {
                    yeniMetin.Append(c);  // E�er karakter �evirme tablosunda yoksa, karakteri oldu�u gibi eklemek
                }
            }

            return yeniMetin.ToString();  // D�n��t�r�len metnin dizeye d�n��t�r�lerek d�nd�r�lmesi
        }


        // Buton2_Click olay�
        private void button2_Click(object sender, EventArgs e)
        {
            // Giri� metni al�nmas�
            string metin = TurkceToIngilizce(richTextBox1.Text);

            // Rotor pozisyonlar�n�n al�nmas�
            string[] pozisyonlar = { textBox1.Text, textBox2.Text, textBox3.Text };  // Rotor pozisyonlar�n�n al�nmas�
            int rotor1Poz = 0, rotor2Poz = 0, rotor3Poz = 0;  // Rotor pozisyonlar� i�in de�i�kenlerin tan�mlanmas�

            // Rotor pozisyonlar�n�n i�lenmesi
            for (int i = 0; i < pozisyonlar.Length; i++)  // Her bir pozisyonun i�lenmesi
            {
                string[] parcalar = pozisyonlar[i].Split('.');  // Pozisyon par�alar�n�n ayr��t�r�lmas�
                if (parcalar.Length == 2 && int.TryParse(parcalar[0], out int rotorNumarasi) && int.TryParse(parcalar[1], out int pozisyon))
                {
                    rotorNumarasi = Math.Max(1, Math.Min(rotors.Length, rotorNumarasi)) - 1;  // Rotor numaras�n�n s�n�rland�r�lmas�
                    pozisyon = (pozisyon % 26 + 26) % 26;  // Pozisyonun s�n�rland�r�lmas�
                    if (i == 0)
                        rotor1Poz = pozisyon;  // Birinci rotorun pozisyonunun atanmas�
                    else if (i == 1)
                        rotor2Poz = pozisyon;  // �kinci rotorun pozisyonunun atanmas�
                    else
                        rotor3Poz = pozisyon;  // ���nc� rotorun pozisyonunun atanmas�
                }
                else
                {
                    MessageBox.Show("Hatal� rot�r pozisyonu: " + pozisyonlar[i]);  // Hata mesaj�n�n g�sterilmesi
                    return;  // Metodun sonland�r�lmas�
                }
            }

            // Metnin �ifrelenmesi ve sonucun richTextBox2'ye eklenmesi
            richTextBox2.Text = Sifrele(metin, rotor1Poz, rotor2Poz, rotor3Poz);  // Metnin �ifrelenmesi ve sonucun richTextBox2'ye yazd�r�lmas�
        }

        // Metnin �ifrelenmesi
        private string Sifrele(string metin, int rotor1Poz, int rotor2Poz, int rotor3Poz)
        {
            StringBuilder sonuc = new StringBuilder();  // Sonu� metni i�in bir StringBuilder nesnesinin olu�turulmas�

            foreach (char c in metin.ToUpper())  // Giri� metninin her bir karakteri i�in d�ng�
            {
                if (char.IsLetter(c))  // Karakterin bir harf olup olmad���n�n kontrol�
                {
                    char karakter = char.ToUpper(c);  // Karakterin b�y�k harfe d�n��t�r�lmesi

                    rotor1Poz = (rotor1Poz + 1) % 26;  // Rotor 1 pozisyonunun g�ncellenmesi
                    if (rotor1Poz == 0)  // Rotor 1 pozisyonunun s�f�ra e�it olup olmad���n�n kontrol�
                    {
                        rotor2Poz = (rotor2Poz + 1) % 26;  // Rotor 2 pozisyonunun g�ncellenmesi
                        if (rotor2Poz == 0)  // Rotor 2 pozisyonunun s�f�ra e�it olup olmad���n�n kontrol�
                        {
                            rotor3Poz = (rotor3Poz + 1) % 26;  // Rotor 3 pozisyonunun g�ncellenmesi
                        }
                    }

                    char rotor1Karakter = rotors[0][(alphabet.IndexOf(c) + rotor1Poz) % 26];  // Rotor 1 �zerindeki harfin �ifrelenmesi
                    char rotor2Karakter = rotors[1][(alphabet.IndexOf(rotor1Karakter) + rotor2Poz) % 26];  // Rotor 2 �zerindeki harfin �ifrelenmesi
                    char rotor3Karakter = rotors[2][(alphabet.IndexOf(rotor2Karakter) + rotor3Poz) % 26];  // Rotor 3 �zerindeki harfin �ifrelenmesi
                    char yansiticiKarakter = reflector[alphabet.IndexOf(rotor3Karakter)];  // Yans�t�c� �zerindeki harfin �ifrelenmesi
                    char rotor3GeriKarakter = alphabet[(rotors[2].IndexOf(yansiticiKarakter) + 26 - rotor3Poz) % 26];  // Rotor 3 geri d�n�� i�lemi
                    char rotor2GeriKarakter = alphabet[(rotors[1].IndexOf(rotor3GeriKarakter) + 26 - rotor2Poz) % 26];  // Rotor 2 geri d�n�� i�lemi
                    char rotor1GeriKarakter = alphabet[(rotors[0].IndexOf(rotor2GeriKarakter) + 26 - rotor1Poz) % 26];  // Rotor 1 geri d�n�� i�lemi
                    sonuc.Append(rotor1GeriKarakter);  // Sonucun son karakterin eklenmesi
                }
                else
                {
                    sonuc.Append(c);  // Karakterin direk olarak sonuca eklenmesi
                }
            }

            return sonuc.ToString();  // Sonucun d�nd�r�lmesi
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form y�klendi�inde yap�lacak i�lemler buraya yaz�labilir.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // TextBox1'in metni de�i�ti�inde yap�lacak i�lemler buraya yaz�labilir.
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // TextBox2'nin metni de�i�ti�inde yap�lacak i�lemler buraya yaz�labilir.
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // TextBox3'�n metni de�i�ti�inde yap�lacak i�lemler buraya yaz�labilir.
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // RichTextBox1'in metni de�i�ti�inde yap�lacak i�lemler buraya yaz�labilir.
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            // RichTextBox2'nin metni de�i�ti�inde yap�lacak i�lemler buraya yaz�labilir.
        }

    }
}
