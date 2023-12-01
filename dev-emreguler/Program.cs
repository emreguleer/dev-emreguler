using System.Xml.Linq;

namespace DairyProject
{
    internal class Program
    {
        static List<string> records { get; set; } = new List<string>();
        static List<string> name { get; set; } = new List<string>();
        static List<string> key { get; set; } = new List<string>();
        static bool limit = true;
        const string path = "C:\\Proje\\Günlük.txt";
        const string usernamepath = "C:\\Proje\\KullanıcıAdı.txt";
        const string passwordpath = "C:\\Proje\\KullanıcıŞifre.txt";
        public static void Main(string[] args)
        {
            Console.WriteLine("Günlüğe Hoşgeldiniz!\n");
            Thread.Sleep(2000);
            // Taking username and password from user.
            Console.WriteLine("(ü)ye girişi  (k)ayıt ol");
            char register = char.Parse(Console.ReadLine());
            if (register == 'ü')
            {
                Control();
            }
            // Creating new username and password then control.
            else if (register == 'k')
            {
                StreamWriter userName = new StreamWriter(usernamepath, true);
                StreamWriter password = new StreamWriter(passwordpath, true);
                Console.WriteLine("Kullanıcı adı giriniz.");
                string name1 = Console.ReadLine();
                Console.WriteLine("Şifre giriniz.");
                string userPassword = Console.ReadLine();
                Console.WriteLine("Kullanıcı adı ve şifre doğru giriş yapabilirsiniz.");
                Thread.Sleep(2000);
                userName.WriteLine(name1);
                password.WriteLine(userPassword);
                name.Add(name1);
                key.Add(userPassword);
                userName.Close();
                password.Close();
                Control();
            }
        }
        //Creating new menu and repeate after every choice.
        public static void Menu()
        {
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Seçiminizi yapınız\n 1. Yeni kayıt ekle\n 2. Kayıtları Listele\n 3. Tüm kayıtları sil\n 4. Çıkış Yap.");
            int choice = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
            if (choice == 1)
            {
                Record();
                Menu();

            }
            else if (choice == 2)
            {
                ListRecords();
                Menu();
            }
            else if (choice == 3)
            {
                Delete();
                Menu();
            }
            else if (choice == 4)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Hatalı sayı girdiniz.");
            }
        }
        //Create new records.
        public static void Record()
        {
            if (limit)
            {
                StreamWriter day = new StreamWriter(path, true);
                Console.WriteLine();
                Console.WriteLine("Gününüz nasıl geçti ? ");
                string yourDay = Console.ReadLine();
                DateTime dateTime = DateTime.Now;
                string date = dateTime.ToString("dd/MM/yyyy");
                string record = $"{date}\n{yourDay}";
                day.WriteLine(record);
                day.WriteLine("--------------");
                records.Add(record);
                Console.WriteLine($"\nGününüz başarıyla {date} tarihinde kaydedilmiştir.");
                limit = false;
                day.Close();
            }
            else
            {
                Console.WriteLine("\nKaydınız girildi. Yeni kayıt oluşturmak ister misiniz ?\n (e)vet (h)ayır");
                char choice = char.Parse(Console.ReadLine());
                if (choice == 'e')
                {
                    limit = true;
                    Record();
                }
                else
                {
                    Console.WriteLine("Menüye yönlendiriliyorsunuz...");
                    Thread.Sleep(1000);
                    Menu();
                }
            }
        }
        //Listing all records.
        public static void ListRecords()
        {
            Console.WriteLine();
            foreach (string days in records)
            {
                Console.WriteLine(days);
            }
        }
        //Deleting all records.
        public static void Delete()
        {
            Console.WriteLine("\nTüm veriler siliniyor.\n Emin misiniz ?\n (e)vet (h)ayır");
            char choice = char.Parse(Console.ReadLine());
            if (choice == 'e')
            {
                Console.WriteLine("\nVerileriniz siliniyor...");
                records.Clear();
                File.Delete(path);
                Console.WriteLine("\nVerileriniz silindi.");
            }
            else if (choice == 'h')
            {
                Console.WriteLine("\nSilme işlemini iptal ettiniz.\n Ana menüye dönmek ister misiniz ?\n (e)vet (h)ayır");
                char choice2 = char.Parse(Console.ReadLine());
                if (choice2 == 'e')
                {
                    Console.WriteLine("\nAna menüye yönelendiriliyorsunuz.");
                    Thread.Sleep(1000);
                    Menu();
                }
                else
                    Console.WriteLine("\nProgram kapatılıyor.");
            }
            else
                Console.WriteLine("\nProgram kapatılıyor.");
        }
        //Creating id and password.
        public static void Control()
        {

            StreamReader userName = new StreamReader(usernamepath);
            StreamReader password = new StreamReader(passwordpath);
            string user = userName.ReadLine();
            string userPassword = password.ReadLine();
            while (user != null)
            {
                user = userName.ReadLine();
                name.Add(user);

            }
            userName.Close();
            while (userPassword != null)
            {
                userPassword = password.ReadLine();
                key.Add(userPassword);

            }
            password.Close();
            Console.WriteLine("Kullanıcı adı giriniz.");
            string name1 = Console.ReadLine();
            Console.WriteLine("Şifre giriniz.");
            string userPassword2 = Console.ReadLine();
            if (name.Contains(name1))
            {
                if (key.Contains(userPassword2))
                {

                    Console.WriteLine("Kullanıcı adı ve şifreniz doğru menüye yönlendiriliyorsunuz.");
                    Menu();
                }
                else
                {
                    Thread.Sleep(1500);
                    Console.WriteLine("Yanlış şifre girdiniz. Tekrar deneyiniz.");
                    Control();
                }
            }
            else
            {
                Thread.Sleep(1500);
                Console.WriteLine("Yanlış kullanıcı adı girdiniz. Tekrar deneyiniz.");
                Control();
            }
        }
    }
}