using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            memberList.idNumberList.Add(new NumberModel("Birkan", "Çakmak", "12312312312"));
            memberList.idNumberList.Add(new NumberModel("Sıla", "Akan", "45645645645"));
            memberList.idNumberList.Add(new NumberModel("Ahmet", "Sayar", "78978978978"));
            memberList.idNumberList.Add(new NumberModel("Büşra", "Kızıl", "12345678910"));
            memberList.idNumberList.Add(new NumberModel("Aslı", "Çakmak", "85285285285"));
            int kayitNo = 0;
            int baskaKayit = 2;
            while (baskaKayit == 2)
            {
                Console.WriteLine("Tc kimlik numaranızı Giriniz:");
                string tc = Console.ReadLine();
                int kayitKontrol = 1;
                foreach (var item in memberList.idNumberList)
                {
                    if (item.Number == tc)
                    {
                        Console.WriteLine("isim: {0}", item.Name);
                        Console.WriteLine("Soyisim: {0}", item.Surname);
                        Console.WriteLine("Tc Kimlik Numarası: {0}", item.Number);
                        Console.WriteLine("-");
                        kayitKontrol = 0;
                        break;
                    }

                }

                if (kayitKontrol == 1)
                {
                    SaveNumber(tc);
                    wiev();
                }
                string siparisMarka = MarkaMethod();
                string siparisRenk = RenkMethod();
                string siparisTaksit = TaksitMethod();

                kayitNo++;
                string stringKayitNo = Convert.ToString(kayitNo);


                SiparisList.SiparisKayitList.Add(new SiparisModel(stringKayitNo, siparisMarka, siparisRenk, siparisTaksit));
                foreach (var item in SiparisList.SiparisKayitList)
                {
                    if (item.StringKayit == stringKayitNo)
                    {
                        Console.WriteLine("Kayıt No: {0}", item.StringKayit);
                        Console.WriteLine("Marka: {0}", item.Marka);
                        Console.WriteLine("Renk: {0}", item.Renk);
                        Console.WriteLine("Taksit: {0}", item.Taksit);
                        Console.WriteLine("-");
                    }
                }
                Console.WriteLine("Uygulamadan çıkılsın :1, Başka bir sipariş 2");
                baskaKayit = Convert.ToInt32(Console.ReadLine());

            }
        }
        static string MarkaMethod()
        {

            Console.WriteLine("Lütfen Satın Almak İstediğiniz Arabanın Markasını Seçiniz" +
               " Audi için 1, Bmw için 2, Mercedes için 3 giriniz");

            string marka = Console.ReadLine();
            string smarka = "";
            if (marka == "1")
                smarka = "Audi";
            else if (marka == "2")
                smarka = "Bmw";
            else if (marka == "3")
                smarka = "Mercedes";
            else
            {
                Console.WriteLine("Yanlış Bir Değer Girdiniz");
                Console.WriteLine();
                return MarkaMethod();
            }
            return smarka;
        }
        static string RenkMethod()
        {

            Console.WriteLine("Lütfen Satın Almak İstediğiniz Rengi Giriniz " +
                "Kırmızı için: 1,Sarı için: 2, Mavi için: 3, Yeşil için: 4");


            string renk = Console.ReadLine();
            string srenk = "";
            if (renk == "1")
                srenk = "Kırmızı";
            else if (renk == "2")
                srenk = "sarı";
            else if (renk == "3")
                srenk = "Mavi";
            else if (renk == "4")
                srenk = "Yeşil";
            else
            {
                Console.WriteLine("Yanlış Bir Değer Girdiniz");
                Console.WriteLine();
                return RenkMethod();
            }
            return srenk;
        }
        static string TaksitMethod()
        {

            Console.WriteLine("Lütfen Kaç Taksit ile Ödemek İstediğniizi Seçiniz " +
           "24 taksit için: 1, 36 taksit için: 2");
            string taksit = Console.ReadLine();


            string staksit = "";
            if (taksit == "1")
                staksit = "24 taksit";
            else if (taksit == "2")
                staksit = "36 taksit";
            else
            {
                Console.WriteLine("Yanlış Bir Değer Girdiniz");
                Console.WriteLine();
                return TaksitMethod();
            }
            return staksit;
        }
        public static void SaveNumber(string tc)
        {
            Console.WriteLine("Lütfen isim giriniz:");
            string name = Console.ReadLine();
            Console.WriteLine("Lütfen soyisim giriniz:");
            string surname = Console.ReadLine();
            string number = tc;
            memberList.idNumberList.Add(new NumberModel(name, surname, number));
        }
        public static void wiev()
        {
            Console.WriteLine("isim: {0}", memberList.idNumberList[memberList.idNumberList.Count - 1].Name);
            Console.WriteLine("Soyisim: {0}", memberList.idNumberList[memberList.idNumberList.Count - 1].Surname);
            Console.WriteLine("Tc Kimlik Numarası: {0}", memberList.idNumberList[memberList.idNumberList.Count - 1].Number);
            Console.WriteLine("-");
        }
    }
    public static class memberList
    {
        public static List<NumberModel> idNumberList = new List<NumberModel>();
    }

    public class NumberModel
    {

        public NumberModel(string name, string surname, string number)
        {
            this.Name = name;
            this.Surname = surname;
            this.Number = number;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Number { get; set; }
    }
    public static class SiparisList
    {
        public static List<SiparisModel> SiparisKayitList = new List<SiparisModel>();
    }
    public class SiparisModel
    {

        public SiparisModel(string stringKayitNo, string marka, string renk, string taksit)
        {
            this.Marka = marka;
            this.Renk = renk;
            this.Taksit = taksit;
            this.StringKayit = stringKayitNo;
        }

        public string Marka { get; set; }
        public string Renk { get; set; }
        public string Taksit { get; set; }
        public string StringKayit { get; set; }
    }
}
