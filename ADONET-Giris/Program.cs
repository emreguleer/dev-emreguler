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
            Console.WriteLine("3-Kategori Güncelle");
            Console.WriteLine("4-Kategori Sil");
            Console.WriteLine("5-Kitap Ekle");
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
                UpdateCategory();
            }
            else if (choice == "4")
            {
                DeleteCategory();
            }
            else if (choice == "5")
            {
                AddBook();
            }
            else
            {
                Console.WriteLine("Hatalı Seçim.");
            }

        }

         static void AddBook()
        {
            Book book = new Book();
            Console.WriteLine("Kitabın adını giriniz.");
            book.Name = Console.ReadLine();
            Console.WriteLine("Kitabın açıklamasını giriniz.");
            book.Description = Console.ReadLine();
            Console.WriteLine("Kitabın ISBN numarasını giriniz.");
            book.ISBN = Console.ReadLine();
            Console.WriteLine("Kitabın sayfa sayısını giriniz.");
            int pageCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen kitabın raf numarasını yazıınz");
            book.ShelfId = ShelfController.Find(Console.ReadLine()).Id;
            bool addCategory = true;
            while (addCategory)
            {
                Console.WriteLine("Kategori giriniz.");
                book.Categories.Add(CategoryController.Find(Console.ReadLine()));
                Console.WriteLine("Yeni bir kategori eklemek ister misiniz ? E/H");
                if (Console.ReadLine() == "H")
                    break;
            }
            while (true)
            {
                Console.WriteLine("Lütfen bir yazar giriiniz");
                book.Authors.Add(AuthorController.Find(Console.ReadLine()));
                Console.WriteLine("Başka bir yazar eklemek ister misiniz ? E/H");
                if (Console.ReadLine() == "H")
                    break;
            }
            //buraya gelindiğinde artık elimizde Categories ' inden Authors' una kadar içi tam dolu bir Book nesnesine sahip olmuş oluyoruz.
            // şimdi bir BookController oluşturup onun içerisine Add metodu tanımlayalım.

        }

        public static void DeleteCategory()
        {
            Console.WriteLine("Silmek istediğiniz kategori ismini giriniz.");
            Console.WriteLine(CategoryController.Delete(new Category() { Name = Console.ReadLine() }) ? "Kategori eklendi":"Hata");
            Thread.Sleep(1500);
        }

        public static void UpdateCategory()
        {
            ListCategory();
            Console.WriteLine("Güncellemek istediğiniz kategoriyi giriniz.");
            Category category = CategoryController.Find(Console.ReadLine());
            if(category.Id != 0)
            {

                Console.WriteLine("Yeni kategori adını giriniz.");
                category.Name = Console.ReadLine();
                Console.WriteLine("Kategori açıklamasını giriniz.");
                category.Description = Console.ReadLine();
                if (CategoryController.Update(category))
                {
                    Console.WriteLine("Başarıyla Güncellenmiştir.");
                }
                else
                {
                    Console.WriteLine("Hata");
                }
            }
            else
            {
                Console.WriteLine("Hata");
            }
            Thread.Sleep(1500);
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