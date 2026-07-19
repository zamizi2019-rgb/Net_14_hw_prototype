using System;

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
            Console.WriteLine("3. Exit");            
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))//проверка вводад
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
            if (!int.TryParse(Console.ReadLine(), out choice))
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
}
