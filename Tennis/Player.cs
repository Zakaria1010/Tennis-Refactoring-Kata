using System;

namespace Tennis
{
    public class Player
    {
        private string name;
        private int score;
        public string result { get; set; }
        public Player(string name)
        {
            this.name = name;
            this.score = 0;
        }

        public int addPoint()
        {
            score++;
            return score;
        }
        public int getScore() { 
            return score; 
        }

        public string getResult()
        {
            return result;
        }

        public bool isTieWidth(Player otherPlayer)
        {
            return score == otherPlayer.score;
        }

        public bool someoneIsAheadByOne(Player otherPlayer)
        {
            return Math.Abs(score - otherPlayer.getScore()) == 1;
        }
        public bool eitherPlayerHasAdvantage(Player otherPlayer)
        {
            return score >= 4 || otherPlayer.score >= 4;
        }
    }

}

