using MasterMind;

/* SPELVERLOOP
De computer kiest random vier letters uit de verzameling {a, b, c, d, e, f}. De gekozen rij wordt verder
“code” genoemd. De volgorde is van belang; een letter mag vaker voorkomen. De gebruiker moet de
verborgen code proberen te achterhalen. De gebruiker geeft een code van vier letters op. De
computer geeft een reactie op de ingegeven code, door te antwoorden met:

• het aantal correcte letters die op de juiste plaats staan
• het aantal correcte letters dat NIET op de juiste plaats staat

De gebruiker geeft nu een nieuwe code op, gebaseerd op deze nieuwe informatie. Als alle vier
letters op de juiste plaats staan, is de code gekraakt en het spel ten einde. Een lopend spel kan
worden beëindigd door het invoeren van een q; alle andere invoer moet ofwel correct zijn (dus in de
verzameling voorkomen), ofwel resulteren in opnieuw bevragen van de gebruiker

TO DO:
- V create highscore List, top 5 from allPlayers list
- V appoint score to player
- V check amount of particapants
- why does AgeCheck(playerAge) give error? (line 45 in GetPlayerDetails())
- make subclasses and interfaces for different age groups
- create friend groups
*/


const string chars = "abcdef";
string playerName;
int playerAge;
int id = 0;
int score;
var allThePlayers = new Dictionary<int, Player>();
//bool permission;


void GetPlayerDetails()
{
    //permission = false;
    Console.Write("Welcome to MasterMind! What's your name?");
    playerName = Console.ReadLine().Trim();
    Console.Write($"Hi {playerName}, what's your age?");
    playerAge = Int32.Parse(Console.ReadLine());
    id++;
    Console.WriteLine($"{id}, {playerName}, {playerAge}");
    //AgeCheck(playerAge);
}
GetPlayerDetails();


//bool AgeCheck(int age)
//{
//    if (age < 18)
//    {
//        Console.Write("Do you have permission from a parent or guardian to play this game(yes/no)?");
//        string answerPermission = Console.ReadLine().Trim().ToLower();
//        if (answerPermission == "yes")
//        {
//            Console.WriteLine("Let's play!");
//            return permission = true;
//        }
//        else
//        {
//            Console.WriteLine("Sorry, as a Minor you can't play without permission");
//            RestartGame();
//            return permission = false;
//        }
//    }
//    else
//    {
//        Console.WriteLine("Let's play!");
//        return permission = true;
//    }
//}




Random randomCode = new Random();
string GetRandomCode(int length)
{
    score = 10;
    return new string(Enumerable.Repeat(chars, length)
      .Select(s => s[randomCode.Next(s.Length)]).ToArray());
}
string codeAnswer = GetRandomCode(4);
Console.WriteLine(codeAnswer);          // for admin to check if it works


void GuessCode()
{
    Console.Write("\nCrack the 4-letter code, use only a, b, c, d, e, f:\t");
    string? input1 = Console.ReadLine().Trim();
    if (input1 == "q" || input1 == "Q")
    {
        Console.WriteLine("\nYou ended the game!\n\n");
        RestartGame();
    } else if (input1 != null)
    {
        CheckAbcdef(input1);
    }
    else
    {
        Console.WriteLine("You didn't type anything, try again!");
    }
}
GuessCode();


void CheckAbcdef(string input)
{
        if (input.All(c => chars.Contains(c)))
        {
            CheckCode(input, codeAnswer);
        }
        else
        {
            Console.WriteLine("You used invalid characters. Try again!");
            score--;
            GuessCode();
    }
}


void RestartGame()
{
    codeAnswer = GetRandomCode(4);
    Console.WriteLine($"\n{codeAnswer}\n");     // for admin to check if it works
    Console.WriteLine("Let's start a new MasterMind game!");
    GetPlayerDetails();
    GuessCode();
}


void getHighScores(int playerScore, Player player)
{
    allThePlayers.Add(playerScore, player);
    var sortedHighScores = from p in allThePlayers
                           orderby p.Key descending
                           select p;

    Console.WriteLine("HIGHSCORES:");
    foreach (var p in sortedHighScores)
    {

        Console.WriteLine($"- points: {p.Value.HighScore}, name: {p.Value.Name}, age: {p.Value.Age}, id no.: {p.Value.Id}");
    }
}


void CheckCode(string input, string correctCode)
{
    if (input.Length == 4)
    {
        int correctLrs = 0;
        int correctLrsWrongSpt = 0;
        int incorrectLrs = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].Equals(correctCode[i]))
            {
                correctLrs++;
            }
            else if (correctCode.Contains(input[i]))
            {
                correctLrsWrongSpt++;
            }
            else
            {
                incorrectLrs++;
            }
        }
        Console.WriteLine($"{correctLrs} correct letter(s) in correct spot\n{correctLrsWrongSpt} correct letter(s) in wrong spot\n{incorrectLrs} incorrect letter(s)");
        //if (input == correctCode)
        //if (correctLrs == 4)
        if (string.Equals(input, correctCode))
        {
            Player p1 = new Player(id, playerAge, playerName);
            Console.WriteLine($"\nCongrats {p1.Name}, you cracked the code!\nYour score: {score} points\nParticipants: {Player.TotalAmountPlayers}");
            p1.SetHighScore(score);
            getHighScores(p1.HighScore, p1);

            Console.WriteLine("\nPress any key for new game\n");
            Console.ReadKey();
            RestartGame();
        } else
        {
            Console.WriteLine("Try again!");
            score--;
            GuessCode();
        }
    }
    else
    {
        Console.Write("Code must have length of 4 letters. Try again!");
        score--;
        GuessCode();
    }
}

