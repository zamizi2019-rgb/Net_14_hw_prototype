public static class LoginRegister
{
    public static User Login()
    {
        Console.Write("Login: ");
        string login = Console.ReadLine();

        if (!Valide.UserExists(login))//если юзера не существует с таким логином. значит не нйаден
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

        if (Valide.UserExists(login))//для индивидуальности, 2 логина одинаковых буть не могут
        {
            Console.WriteLine("User with this login already exists, try another one");
            return;
        }

        if (!Valide.ValidUser(login))
        {
            Console.WriteLine("Login has to contain only letters and digits and has to be at least 4 characters long");
            return;
        }

        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (!Valide.ValidPassword(password))
        {
            Console.WriteLine("Password has to contain only letters and digits and has to be at least 4 characters long");
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
    public static Admin LoginAdmin()
    {
        Console.Write("Login: ");
        string login = Console.ReadLine();
        if (!Valide.AdminExists (login))//если нет админа, то просто возвращаем нулл
        {
            Console.WriteLine("User not found");
            return null;
        }
        Console.Write("Password: ");
        string password = Console.ReadLine();

        foreach (Admin admin in GameData.Admins)
        {
            if (admin.Login == login && admin.Password == password)
            {
                Console.WriteLine("Successfull entry!");
                return admin;
            }
        }
        Console.WriteLine("Incorrect password");
        return null;
    }
}
