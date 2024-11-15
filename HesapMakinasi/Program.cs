using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace HesapMakinasi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? sayi1s;
            string? sayi2s;
            double sonuc = 0;
            bool dongu = true;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hesap Makinasına hoşgeldiniz");
            while (dongu==true)
            {
                Console.WriteLine("Sıra ile 2 sayı giriniz");
                Console.WriteLine("1. sayıyı giriniz");
                sayi1s = Console.ReadLine();


                double sayi1 = 0;
                while (!double.TryParse(sayi1s, out sayi1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçerli bir sayı girmediniz tekrar deneyiniz");
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Green;
                    sayi1s = Console.ReadLine();
                }


                Console.WriteLine("2. Sayıyı Giriniz");
                sayi2s = Console.ReadLine();

                double sayi2 = 0;
                while (!double.TryParse(sayi2s, out sayi2))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Geçerli bir sayı girmediniz tekrar deneyiniz");
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Green;
                    sayi2s = Console.ReadLine();
                }


                bool islemdogru = false;
                while (islemdogru == false) {
                    Console.WriteLine("Yapmak istediğiniz işlem hangisidir\n\tToplama:+\n\tÇıkarma:-\n\tÇarpma:x,*\n\tBölme:/,÷\n\tYüzde:%");
                    string? islemsembol;
                    islemsembol = Console.ReadLine();
                    if (islemsembol == null ||!Regex.IsMatch(islemsembol, @"^[+\-*/x÷%]$"))
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Bilinmeyen karakter");
                        Console.Beep() ;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else { 
                        switch (islemsembol[0])
                        {
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("İşlem Türü belirlenemedi");
                                Console.Beep();
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case '+':
                                sonuc = Hesaplamalar.Toplama(sayi1, sayi2);
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("İşlemde bir hata oluştu"); 
                            Console.Beep();
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            islemdogru = true;
                            Console.WriteLine($"\nSonuç:\n{sayi1}{islemsembol}{sayi2}:\n{sonuc}");
                        }
                    }
                }
                Console.WriteLine("\n\nKapatmak için 'k' basın ve enterlayın");
                Console.WriteLine("Devam Etmek için sadece enterlayın");
                if (Console.ReadLine() == "k") { dongu = false; }
            }
        }
    }
}
