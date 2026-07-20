using System.Text.Json;

public static class FileManager
{
    public static void LoadUsers()//загрузка юзера из файла
    {
        if (!File.Exists("Users.json"))
        {
            GameData.Users = new List<User>();
            return;
        }

        string json = File.ReadAllText("Users.json");
        GameData.Users = JsonSerializer.Deserialize<List<User>>(json);

        if (GameData.Users == null)
        {
            GameData.Users = new List<User>();
        }
    }
    public static void SaveUsers()//сохранение юзера
    {
        string json = JsonSerializer.Serialize(GameData.Users);
        File.WriteAllText("Users.json", json);
    }
    public static void LoadQuizzes()//она делает так что используя переменные мы можем обращаться к самому файлу и брать оттуда нужные нам строки и тд
    {
        GameData.HistoryQuiz = LoadQuiz("History.json");
        GameData.BiologyQuiz = LoadQuiz("Biology.json");
        GameData.GeographyQuiz = LoadQuiz("Geography.json");
    }
    private static QuizData LoadQuiz(string path)
    {
        if (!File.Exists(path))//проверка на существование файла
        {
            Console.WriteLine($"File {path} was not found!");
            return null;
        }

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<QuizData>(json);//возвращает новый quizdata объект из джейсон строки
    }
}
