public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime Birthday { get; set; }
    public List<QuizResult> Results { get; set; } = new List<QuizResult>();//у каждого юзера хранятся свои результаты тестирований
    public User() {}//для сериализации пустой конструктор
    public User(string login, string password, DateTime birthday)
    {
        Login = login;
        Password = password;
        Birthday = birthday;
        Results = new List<QuizResult>();
    }
}

public class QuizResult
{
    public string Topic { get; set; }//название темы
    public int Score { get; set; }
    public DateTime Date { get; set; }
}

public class TopResult
{
    public string Login { get; set; }
    public int Score { get; set; }
}

public class QuizQuestion
{
    public string Text { get; set; }
    public List<string> Answers { get; set; }
    public int CorrectIndex { get; set; }
}

public class QuizData
{
    public string Topic { get; set; }//просто название биология, история , географяф
    public List<QuizQuestion> Questions { get; set; }
}
