using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace HesapMakinasi
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            string? sayi1s;
            string? sayi2s;
            bool dongu = true;

            Console.ForegroundColor = ConsoleColor.Green;            //Giriş
            Console.WriteLine("Hesap Makinasına hoşgeldiniz");
            while (dongu==true)                                     //Hesap makinasının işlem sonrası devamı için döngü
            {
                double sonuc = 0;
                Console.WriteLine("Sıra ile 2 sayı giriniz");       //İlk sayı girişi
                Console.WriteLine("1. sayıyı giriniz");
                sayi1s = Console.ReadLine();


                double sayi1 = 0;
                while (!double.TryParse(sayi1s, out sayi1))         //Girilen bilgilerin double'a dönüşebildiğinden emin olan loop
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçerli bir sayı girmediniz tekrar deneyiniz");  //While içerideki TryParse'ı çalıştırıyor                                                         
                    Console.ForegroundColor = ConsoleColor.Green;                       //TryParse eğer dönüştürebilirse true dönüştüremezse false veriyor
                    sayi1s = Console.ReadLine();                                        //(!) kullanarak false olduğu süre boyunca loop aktif kalıyor
                }


                Console.WriteLine("2. Sayıyı Giriniz");
                sayi2s = Console.ReadLine();

                double sayi2 = 0;
                while (!double.TryParse(sayi2s, out sayi2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçerli bir sayı girmediniz tekrar deneyiniz");
                    Console.ForegroundColor = ConsoleColor.Green;
                    sayi2s = Console.ReadLine();
                }


                bool islemdogru = false;
                while (islemdogru == false) {
                    Console.WriteLine("Yapmak istediğiniz işlem hangisidir\n\tToplama:+\n\tÇıkarma:-\n\tÇarpma:x,*\n\tBölme:/,÷\n\tYüzde:%"); //Burası en zor kısımdı 
                    string? islemsembol;  //Öncelikle direkt stringin birer char dizisi oluşundan sadece switch islemsembol[0] dan bulmaya çalışıyordum ama boş değer girilirse                                                                                                
                    islemsembol = Console.ReadLine(); //Program exception veriyordu
                    if (islemsembol == null ||!Regex.IsMatch(islemsembol, @"^[+\-*/x÷%]$")) //Biraz araştırdım bir stringi diğer stringe tam uyması durumunu Regex.IsMatch buldum Ama burada "-" karakteri sıkıntı çıkardı.Sonra \ koyarak bunu çözdüm
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Bilinmeyen karakter");
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else { 
                        switch (islemsembol[0])//Eskiden Kalmış bir kısımdı Değiştirmedim ama eğer değiştirilirse bütün caseler '' kullanmaktan "" geçirilmeli çünkü '' bir karakteri ifade ediyor
                        {
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("İşlem Türü belirlenemedi");
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case '+':
                                sonuc = Hesaplamalar.Toplama(sayi1, sayi2);   //Burada switch case kısmınıda Hesaplamalar.cs ye bırakabilirdim ama burda yaparken debuglamak daha kolaydı
                                break;
                            case '-':
                                sonuc = Hesaplamalar.Cikarma(sayi1, sayi2);
                                break;
                            case '*':
                            case 'x':
                                sonuc = Hesaplamalar.Carpma(sayi1, sayi2);
                                break;
                            case '/':
                            case '÷':
                                sonuc = Hesaplamalar.Bolme(sayi1, sayi2);
                                break;
                            case '%':
                                sonuc = Hesaplamalar.Yuzde(sayi1, sayi2);
                                break;
                        }
                        if (double.IsNaN(sonuc)) { 
                            Console.ForegroundColor = ConsoleColor.Red;    //Eğer unuttuğum bir bug bir belirisiz matematik sonucu olursu IsNan bulsun diye koydum
                            Console.WriteLine("İşlemde bir hata oluştu");  //bütün bu kısmı try'a alıp herhangibir hatada catch exception yapılabilirmiş. StackOverFlow tavsiyesi--
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            islemdogru = true;
                            Console.WriteLine($"\nSonuç:\n{sayi1}{islemsembol}{sayi2}:\n{sonuc}");
                        }
                    }
                }
                Console.WriteLine("\n\nKapatmak için 'k' basın ve enterlayın");  //Evet burada sadece k kabul ediliyor Regex kullanarak daha fazla şey kabul edebilirdim
                Console.WriteLine("Devam Etmek için sadece enterlayın");        //Ama gereksiz uzatırdı
                //Console.WriteLine(GC.GetTotalMemory(false)); Uygulama 196.76kb kullanıyor daha iyi optimize edilebilir galiba...
                if (Console.ReadLine() == "k") { dongu = false; }             
            }
        }
    }
}
