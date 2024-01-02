using System.ComponentModel.Design;
using System.Xml.Serialization;

namespace ADONET_Giris
{
    internal class Program
    {
        static void Main(string[] args)
        {
         while(true)
            {
                Menu();
            }   
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1-Kategori Ekle");
            Console.WriteLine("2-Kategori Listele");
            Console.WriteLine("3-Kategori bul");
            Console.WriteLine("4-Kategori Güncelle");
            Console.WriteLine("5-Kategori Sil");
            string choice = Console.ReadLine();
            Choice(choice);
        }

        public static string Choice(string choice)
        {
            
        }
    }
}