using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Player
    {
        public int Id
        { get; protected set; }

        public int Age
        { get; protected set; }

        public string Name
        { get; protected set; }

        public static int TotalAmountPlayers;

        public int HighScore
        { get; protected set; }


    public Player (int id, int age, string name)
        {
            Age = age;
            Name = name;
            Id = id;
            TotalAmountPlayers++;
            HighScore = 0;
        }

        public int SetHighScore(int score)
        {
            return HighScore = score > HighScore ? score : HighScore;
        }


    }
}
