using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesapMakinasi
{
    internal class Hesaplamalar
    {
        public static double Toplama(double sayi1, double sayi2)
        { return (sayi1 + sayi2); }
        public static double Cikarma(double sayi1, double sayi2)
        { return (sayi1 - sayi2); }
        public static double Carpma(double sayi1, double sayi2)
        { return (sayi1 * sayi2); }
        public static double Bolme(double sayi1, double sayi2)
        {
        
                while (sayi2 == 0)
                {
                    string? sayi2s = "";
                    {
                        while (!double.TryParse(sayi2s, out sayi2))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("0 Sayısı başka bir sayıya bölünemez lütfen başka sayı giriniz.");
                            Console.Beep();
                            Console.ForegroundColor = ConsoleColor.Green;
                            sayi2s = Console.ReadLine();
                        }
                    }
                }
            
                return (sayi1 / sayi2);
        }
            public static double Yuzde(double sayi1, double sayi2)
            { return ((sayi2 * 100) / sayi1); }
    }
}
