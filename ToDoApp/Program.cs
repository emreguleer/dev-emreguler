using System.ComponentModel.Design;

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
            else
            {
                Console.WriteLine("Hata");
            }
        }
        
            
       
    }
}