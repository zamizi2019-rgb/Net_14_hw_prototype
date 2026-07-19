public static class Valide
{
    public static bool ValidUser(string login)
    {
        foreach (char c in login)
        {
            if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')))
            {
                return false;
            }
        }
        return true;
    }

    public static bool ValidPassword(string password)
    {
        foreach (char c in password)
        {
            if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')))
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckBirthday(string date, out DateTime birthday)
    {
        if (!DateTime.TryParse(date, out birthday))
        {
            return false;
        }
        if (birthday > DateTime.Now)
        {
            return false;
        }

        return true;
    }

    public static bool UserExists(string login)
    {
        foreach (User user in GameData.Users)
        {
            if (user.Login == login)
            { 
                return true;
            }
        }
        return false;
    }
}
