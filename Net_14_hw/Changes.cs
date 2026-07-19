public static class Changes
{
    public static void ChangeSettings(User user)
    {
        Console.WriteLine("\n1. Change password");
        Console.WriteLine("2. Change birth date");
        Console.Write("3. Exit");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Incorrect choice");
        }

        if (choice == 1)
        {
            Console.Write("New password: ");
            string password = Console.ReadLine();

            if (Valide.ValidPassword(password))
            {
                user.Password = password;
                FileManager.SaveUsers();
                Console.WriteLine("Password changd successfully");
            }
            else
            {
                Console.WriteLine("Password has to contain only letters and digits");
            }
        }
        else if (choice == 2)
        {
            Console.Write("New birth date (yyyy-MM-dd): ");
            string date = Console.ReadLine();

            if (Valide.CheckBirthday(date, out DateTime birthday))
            {
                user.Birthday = birthday;
                FileManager.SaveUsers();
                Console.WriteLine("birth date changed");
            }
            else
            {
                Console.WriteLine("Incorrect date");
            }
        }
        else if (choice == 3)
        {
            return;
        }
    }
}
