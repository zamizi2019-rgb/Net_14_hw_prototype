public static class TopManager
{
    public static void Top20()
    {
        Console.WriteLine("\nChoose topic");
        Console.WriteLine("1) History");
        Console.WriteLine("2) Biology");
        Console.WriteLine("3) Geography");
        Console.WriteLine("4) Mix Quiz");
        Console.WriteLine("5) Exit");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("Enter a number from 1 to 5");
        }

        string topic = "";
        if (choice == 1)
        {
            topic = "History";
        }
        else if (choice == 2)
        {
            topic = "Biology";
        }
        else if (choice == 3) 
        {
            topic = "Geography";
        } 
        else if (choice == 4)
        {
            topic = "Mix";
        }
        else if (choice == 5)
        {
            return;
        }

        List<TopResult> top = new List<TopResult>();

        foreach (User user in GameData.Users)
        {
            int bestScore = -1;
            foreach (QuizResult result in user.Results)
            {
                if (result.Topic == topic && result.Score > bestScore)
                {
                    bestScore = result.Score;
                }
            }
            if (bestScore != -1)//если результат больше -1, значит кто то прошел в топ 20
            {
                top.Add(new TopResult { Login = user.Login, Score = bestScore });
            }
        }

        top = top.OrderByDescending(x => x.Score).ToList();//сортировка топа 

        Console.WriteLine($"Top20 - {topic}:");
        int count = Math.Min(20, top.Count);

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"{i + 1}. {top[i].Login} - {top[i].Score}/20");
        }

        if (count == 0)
            Console.WriteLine("No results");
    }
}