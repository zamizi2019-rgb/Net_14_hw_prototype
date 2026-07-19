using System.Text.Json;

public static class FileManager
{
    public static void LoadUsers()
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
    public static void SaveUsers()
    {
        string json = JsonSerializer.Serialize(GameData.Users);
        File.WriteAllText("Users.json", json);
    }
    public static void LoadQuizzes()
    {
        GameData.HistoryQuiz = LoadQuiz("Quizzes/history.json");
        GameData.BiologyQuiz = LoadQuiz("Quizzes/biology.json");
        GameData.GeographyQuiz = LoadQuiz("Quizzes/geography.json");
    }
    private static QuizData LoadQuiz(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine($"File {path} was not found!");
            return null;
        }

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<QuizData>(json);
    }
}