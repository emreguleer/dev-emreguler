using ADONET_Giris.Controller;
using ADONET_Giris.Models;
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

        public static void Choice(string choice)
        {
            if (choice == "1")
            {
                AddCategory();
            }
            else if (choice == "2")
            {
                ListCategory();
            }
            else if (choice == "3")
            {
                FindCategory();
            }
            else if (choice == "4")
            {
                UpdateCategory();
            }
            else if (choice == "5")
            {
                DeleteCategory();
            }
            else
            {
                Console.WriteLine("Hatalı Seçim.");
            }

        }

        public static void DeleteCategory()
        {
            Console.WriteLine("Silmek istediğiniz kategori ismini giriniz.");
            Console.WriteLine(CategoryController.Delete(new Category() { Name = Console.ReadLine() }) ? "Kategori eklendi":"Hata");
        }

        public static void UpdateCategory()
        {
            Console.WriteLine("Güncellemek istediğiniz kategoriyi giriniz.");
            Category category = new Category();
            category.Name = Console.ReadLine();
            Console.WriteLine(CategoryController.Update(new Category() { Name = Console.ReadLine()})? "Kategori güncellendi":"Hata");

        }

        public static void FindCategory()
        {
            Console.WriteLine("Bulmak istediğiniz kategoriyi giriniz.");
            Category category = new Category();
            category.Name = Console.ReadLine();
            CategoryController.Find(category).ForEach(x => Console.WriteLine(x.Id + "-" + x.Name + x.Description == null ? "" : "(" + x.Description + ")"));
        }

        public static void ListCategory()
        {
            Console.WriteLine("Tüm Kategoriler");
            Console.WriteLine("---------------");
            List<Category> list = new List<Category>();
            CategoryController.GetAll().ForEach(x => Console.WriteLine(x.Id + "-" + x.Name + x.Description == null? "":"(" + x.Description + ")" ));
            Thread.Sleep(1500);
        }  

        public static void AddCategory()
        {
            Console.WriteLine("Kategori Adı Giriniz.");
            Console.WriteLine(CategoryController.Add(new Category() { Name = Console.ReadLine() }) ? "Kategori Eklendi" : "Hata");
            Thread.Sleep(1500); 
        }
    }
}