using System.ComponentModel.Design;
using ToDoApp.Controller;
using ToDoApp.Models;

namespace ToDoApp
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

        static void Menu()
        {
            Console.WriteLine("1-ToDo ekle.");
            Console.WriteLine("2-ToDo Listele");
            Console.WriteLine("3-ToDo Güncelle");
            Console.WriteLine("4-Status ekle");
            Console.WriteLine("5-Status Listele");
            Console.WriteLine("6-Priority Ekle");
            Console.WriteLine("7-Priority Listele");
            Console.WriteLine("8-Tag Ekle");
            Console.WriteLine("9-Tag Listele");
            Console.WriteLine("10-Tag Güncelle");
            string choice = (Console.ReadLine());
            Choice(choice);
        }

        static void Choice(string choice)
        {

            if (choice == "1")
            {
                AddToDo();
            }
            else if (choice == "2")
            {
                ListToDo();
            }
            else if (choice == "3")
            {
                UpdateToDo();
            }
            else if (choice == "4")
            {
                AddStatus();
            }
            else if (choice == "5")
            {
                ListStatus();
            }
            else if (choice == "6")
            {
                AddPriority();
            }
            else if (choice == "7")
            {
                ListPriority();
            }
            else if (choice == "8")
            {
                AddTag();
            }
            else if (choice == "9")
            {
                ListTag();
            }
            else if (choice == "10")
            {
                UpdateTag();
            }
            else
            {
                Console.WriteLine("Hata");
            }
        }

        private static void AddToDo()
        {
            throw new NotImplementedException();
        }

        private static void ListToDo()
        {
            throw new NotImplementedException();
        }

        private static void UpdateToDo()
        {
            throw new NotImplementedException();
        }

        private static void ListPriority()
        {
            throw new NotImplementedException();
        }

        private static void UpdateTag()
        {
            ListTag();
            Console.WriteLine("\nLütfen güncellemek istediğiniz etiketin ID'sini giriniz.");
            int id = int.Parse(Console.ReadLine());
            Tag tag = TagController.FindById(id);
            Console.WriteLine("Lütfen etiketin yeni adını giriniz.");
            tag.Name = Console.ReadLine();
            if (TagController.Update(tag))
            {
                Console.WriteLine("Başarıyla güncellendi");
            }
            else 
            {
                Console.WriteLine("Hata");
            }
        }

        private static void ListTag()
        {
            List<Tag> list = TagController.GetAll();
            foreach (Tag tag in list)
            {
                Console.Write($"{tag.Id} - {tag.Name} | ");
            }
        }

        private static void AddTag()
        {
            Console.WriteLine("Önceliğinizi seçiniz.");
            if (TagController.Add(new Tag { Name = Console.ReadLine() }))
                Console.WriteLine("Öncelik belirlendi.");
            else
                Console.WriteLine("Hata.");
        }

        private static void AddPriority()
        {
            Console.WriteLine("Önceliğinizi seçiniz.");
            if (PriorityController.Add(new Priority { Name = Console.ReadLine() }))
                Console.WriteLine("Öncelik belirlendi.");
            else
                Console.WriteLine("Hata.");
                
        }

        private static void ListStatus()
        {
            throw new NotImplementedException();
        }

        static void AddStatus()
        {
            Console.WriteLine("Lütfen status ismini giriniz.");
            //string statusName = Console.ReadLine();
            //Status status = new Status { Name = statusName};
            if(StatusController.Add(new Status { Name = Console.ReadLine()}))
            { 
                Console.WriteLine("Status eklendi.");
            }
            else 
            {
                Console.WriteLine("Hata oluştur.");
            }
            Thread.Sleep(1000);
        }
    }
}