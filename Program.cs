class Program
{
    public static void Main()
    {
        Console.WriteLine("Willkommen zu Hangman");
        SelectMode();
    }

    static void SelectMode()
    {
        Console.Write("Wähle einen Spielmodus: [1] mit eigenen Wörtern; [2] mit zufälligen Wörtern (deutsch, alle Wörter mit 5-10 Buchstaben): ");
        string input = Console.ReadLine()!;
        getWord(input);
    }
    static void Game(char[] word)
    {
        int lifes = 10;
        char[] disp = new char[word.Length];
        for (int i = 0; i < disp.Length; i++)
        {
            disp[i] = '-';
        }
        print(disp);
        Console.Write("\n");
        while (true)
        {
            Console.WriteLine($"Du hast noch {lifes} Leben");
            Console.Write("Enter a char: ");
            var inp = Console.ReadKey();
            Console.Write("\n");
            int match = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (inp.KeyChar == word[i])
                {
                    disp[i] = word[i];
                    match++;
                }
            }
            Console.Clear();
            print(disp);
            if (WinDetection(disp))
            {
                Console.Write("Du hast gewonnen!");
                Console.ReadKey();
            }
            if (match == 0)
            {
                lifes--;
            }
            if (lifes == 0)
            {
                Console.WriteLine("Leider hast du verloren");
                Console.ReadKey();
                break;
            }
        }
        Console.Clear();
        print(disp);
        print(word);
        Console.Write(new String(word));
        PlayAgain();
    }

    static void PlayAgain()
    {
        Console.Write("Möchtest du nochmal spielen?. [Y/N]: ");
        if (Console.ReadLine()!.ToLower() == "y")
        {
            SelectMode();
        }
    }

    static char[] getWord(string gamevariation)
    {
        string input = "";
        char[] word = new char[10];

        if (gamevariation == "1")
        {
            Console.Write("Please Enter a word: ");
            input = Console.ReadLine()!;
            Console.Clear();
            word = input.ToLower().ToCharArray();
        }
        else if (gamevariation == "2")
        {
            word = SelectWord().ToCharArray();
        }
        return word;
    }
    static void print(char[] disp)
    {
        for (int i = 0; i < disp.Length; i++)
        {
            Console.Write(disp[i]);
        }
        Console.Write("\n");
    }

    static bool WinDetection(char[] word)
    {
        if (word.Contains('-'))
        {
            return false;
        }
        return true;
    }
    static string SelectWord()
    {
        Console.WriteLine("Lädt...");
        string allWords = Wordlist.List;
        string[] words = allWords.Split('\n');
        Console.WriteLine("Fertig!");
        Random random = new Random();
        return words[random.Next(0, words.Length)].ToLower();
    }
}