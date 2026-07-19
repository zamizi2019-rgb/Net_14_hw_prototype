
public static class LoginRegister
{
    public static User Login()
    {
        Console.Write("Login: ");
        string login = Console.ReadLine();

        if (!Valide.UserExists(login))
        {
            Console.WriteLine("User not found");
            return null;
        }

        Console.Write("Password: ");
        string password = Console.ReadLine();

        foreach (User user in GameData.Users)
        {
            if (user.Login == login && user.Password == password)
            {
                Console.WriteLine("Successfull entry!");
                return user;
            }
        }

        Console.WriteLine("Incorrect password");
        return null;
    }

    public static void Register()
    {
        Console.Write("Login: ");
        string login = Console.ReadLine();

        if (Valide.UserExists(login))
        {
            Console.WriteLine("User with this login already exists, try another one");
            return;
        }

        if (!Valide.ValidUser(login))
        {
            Console.WriteLine("Login has to contain only letters and digits");
            return;
        }

        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (!Valide.ValidPassword(password))
        {
            Console.WriteLine("Password has to contain only letters and digits");
            return;
        }

        Console.Write("Birth date (yyyy-MM-dd): ");
        string date = Console.ReadLine();

        if (!Valide.CheckBirthday(date, out DateTime birthday))
        {
            Console.WriteLine("Incorrect date");
            return;
        }

        User user = new User(login, password, birthday);
        GameData.Users.Add(user);
        FileManager.SaveUsers();

        Console.WriteLine("Successfull registration!");
    }
}
