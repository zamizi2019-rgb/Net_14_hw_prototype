public static class Menu
{
    public static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===QUIZ===");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Admin");
            Console.WriteLine("4. Exit");            
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice<1 || choice>4)//проверка ввода
            {
                continue;
            }
            
            if (choice == 1)
            {
                User user = LoginRegister.Login();
                if (user != null)
                {
                    UserMenu(user);
                }
                Console.ReadKey();
            }
            else if (choice == 2)
            {
                LoginRegister.Register();
                Console.ReadKey();
            }
            else if (choice == 3)
            {
                Admin admin = LoginRegister.LoginAdmin();
                if (admin != null)
                {
                    AdminMenu(admin);
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("Bye bye");
                Environment.Exit(0);
            }
        }
    }
    
    public static void UserMenu(User user)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"==={user.Login}===");
            Console.WriteLine("1. Start Quiz");
            Console.WriteLine("2. My results");
            Console.WriteLine("3. Top20");
            Console.WriteLine("4. Change info");
            Console.WriteLine("5. Exit");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
            {
                continue;
            }
            
            if (choice == 1)
            {
                Quiz.StartQuiz(user);
                Console.ReadKey();
            }
            else if (choice == 2)
            {
                Quiz.PreviousQuizResults(user);
                Console.ReadKey();
            }
            else if (choice == 3)
            {
                TopManager.Top20();
                Console.ReadKey();
            }
            else if (choice == 4)
            {
                Changes.ChangeSettings(user);
                Console.ReadKey();
            }
            else if (choice == 5)
            {
                return;
            }
        }
    }
    public static void AdminMenu(Admin admin)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"=== {admin.Login} ===");
            Console.WriteLine("1. Edit History");
            Console.WriteLine("2. Edit Biology");
            Console.WriteLine("3. Edit Geography");
            Console.WriteLine("4. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                continue;
            }

            if (choice == 1)
            {
                Quiz.EditQuestion(GameData.HistoryQuiz);
            }
            else if (choice == 2)
            {
                Quiz.EditQuestion(GameData.BiologyQuiz);
            }
            else if (choice == 3)
            {
                Quiz.EditQuestion(GameData.GeographyQuiz);
            }
            else if (choice == 4)
            {
                return;
            }
        }
    }
}
