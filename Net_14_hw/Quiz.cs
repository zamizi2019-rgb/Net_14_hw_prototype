public static class Quiz
{
    public static void StartQuiz(User user)//меню выбора квиза
    {
        Console.WriteLine("\nChoose topic");
        Console.WriteLine("1) History");
        Console.WriteLine("2) Biology");
        Console.WriteLine("3) Geography");
        Console.WriteLine("4) Mix Quiz");
        Console.WriteLine("5) Exit");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)//проверка на корректный выбор
        {
            Console.WriteLine("You have to Enter number from 1 to 5");
        }

        int score = 0;
        string topic = "";

        if (choice == 1)
        {
            topic = "History";
            score = RunQuiz(GameData.HistoryQuiz);
        }
        else if (choice == 2)
        {
            topic = "Biology";
            score = RunQuiz(GameData.BiologyQuiz);
        }
        else if (choice == 3)
        {
            topic = "Geography";
            score = RunQuiz(GameData.GeographyQuiz);
        }
        else if (choice == 4)
        {
            topic = "Mix";
            score = RunMixedQuiz();
        }
        else if (choice == 5)
        {
            return;
        }

        user.Results.Add(new QuizResult { Topic = topic, Score = score, Date = DateTime.Now });//добавляем результат юзеру
        FileManager.SaveUsers();//сохраняем данные юзера в файл

        Console.WriteLine($"\nQuiz is finished! Your result: {score}/20");//оценка
        ShowPlace(user, topic);//место в топе
    }

    private static int RunQuiz(QuizData quiz)//прохождение теста
    {
        int score = 0;
        for (int i = 0; i < quiz.Questions.Count; i++)//обычно до 20, но этот вариан дял универсальности
        {
            var q = quiz.Questions[i];
            Console.WriteLine($"\nQuestion {i + 1}: {q.Text}");

            for (int j = 0; j < q.Answers.Count; j++)
            {
                Console.WriteLine($"{j + 1}) {q.Answers[j]}");//для красоты
            }
            Console.Write("Your answer: ");
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > q.Answers.Count)
            {
                Console.WriteLine($"Enter a number from 1 to {q.Answers.Count}");//так как ансер каунт всегда 4 мог бы и заменить, но так круче
            }

            if (answer - 1 == q.CorrectIndex)//проверка правильного ответа
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect!");
            }
        }

        return score;
    }

    private static int RunMixedQuiz()
    {
        Random random = new Random();
        var allQuestions = new List<QuizQuestion>();//тут будет список всех вопросов из всех тем

        allQuestions.AddRange(GameData.HistoryQuiz.Questions);
        allQuestions.AddRange(GameData.BiologyQuiz.Questions);
        allQuestions.AddRange(GameData.GeographyQuiz.Questions);

        for (int i = allQuestions.Count - 1; i > 0; i--)//перемешивание вопросов для рандома
        {
            int j = random.Next(i + 1);
            var temp = allQuestions[i];
            allQuestions[i] = allQuestions[j];
            allQuestions[j] = temp;
        }

        int score = 0;

        for (int i = 0; i < 20; i++)//просто вопрос-ответ
        {
            var q = allQuestions[i];

            Console.WriteLine($"\nQuestion{i + 1}: {q.Text}");

            for (int j = 0; j < q.Answers.Count; j++)
            {
                Console.WriteLine($"{j + 1}) {q.Answers[j]}");
            }

            Console.Write("Your answer: ");
            int answer;
            while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > q.Answers.Count)
            {
                Console.WriteLine($"Enter a number from 1 to {q.Answers.Count}");
            }

            if (answer - 1 == q.CorrectIndex)
            {
                Console.WriteLine("Correct!");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect!");
            }
        }

        return score;
    }

    private static void ShowPlace(User thisuser, string topic)//для показа места в топе 
    {
        List<TopResult> top = new List<TopResult>();

        foreach (User user in GameData.Users)//создает топ
        {
            int bestScore = -1;
            foreach (QuizResult result in user.Results)
            {
                if (result.Topic == topic && result.Score > bestScore)
                {
                    bestScore = result.Score;
                }
            }
            if (bestScore != -1)
            {
                top.Add(new TopResult { Login = user.Login, Score = bestScore });
            }
        }

        top.Sort((x, y) => y.Score.CompareTo(x.Score));

        for (int i = 0; i < top.Count; i++)//проверяет, есть ли юзер в топе
        {
            if (top[i].Login == thisuser.Login)
            {
                Console.WriteLine($"Youe place: {i + 1}");
                return;
            }
        }
    }

    public static void PreviousQuizResults(User user)
    {
        if (user.Results.Count == 0)
        {
            Console.WriteLine("No results.");
            return;
        }

        foreach (QuizResult result in user.Results)//показывает твои прошлые результаты
        {
            Console.WriteLine($"{result.Date}: {result.Topic} - {result.Score}/20");
        }
    }
}
    }
}
