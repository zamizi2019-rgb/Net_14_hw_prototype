public static class Valide//кастомные проверки пароля и логина( без спец символов)
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
        if (!DateTime.TryParse(date, out birthday))//проверка на дата ли эьто
        {
            return false;
        }
        if (birthday > DateTime.Now)//провнерка на то что эта дата , до нынешней
        {
            return false;
        }

        return true;
    }

    public static bool UserExists(string login)//существует ли пользователь с таким логином уже
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
