using System;
using static System.Formats.Asn1.AsnWriter;

namespace Tennis
{
    // Single Responsability Principle
    // Eliminate primitive obsession
    // Eliminate Feature envy
    public class TennisGame1 : ITennisGame
    {

        public Player player1;
        public Player player2;

        

        public TennisGame1(string player1Name, string player2Name)
        {

            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                player1.addPoint();
            }
            else
            {
                player2.addPoint();
            }
        }

        public string GetScore()
        {  
           return Arbiter.determinResult(player1, player2).getScoreAsText();         
        }
    }


    class Arbiter
    {
        public static Result determinResult(Player player1, Player player2)
        {
            if (player1.isTieWidth(player2))
            {
                return new EqualityResult(player1, player2);
            }
            else if (eitherPlayerHasAdvantage(player1.getScore(), player2.getScore()) && someoneIsAheadByOne(player1, player2))
            {
                return new AdvantageResult(player1, player2);
            }
            else if (eitherPlayerHasAdvantage(player1.getScore(), player2.getScore()))
            {
                return new WinResult(player1, player2);
            }
            else
            {
                return new OnGoingResult(player1, player2);
            }
        }

        public static bool someoneIsAheadByOne(Player player1, Player otherPlayer)
        {
            return Math.Abs(player1.getScore() - otherPlayer.getScore()) == 1;
        }
        public static bool eitherPlayerHasAdvantage(int player1Score, int player2Score)
        {
            return player1Score >= 4 || player2Score >= 4;
        }
    }
    class OnGoingResult : Result
    {
        public OnGoingResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
           return getScoreAsString(player1.getScore()) + "-" + getScoreAsString(player2.getScore());
        }

        private string getScoreAsString(int tempScore)
        {
            switch (tempScore)
            {
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    return "Love";
            }
        }

         
    }

    class AdvantageResult : Result
    {
        public AdvantageResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
            var minusResult = (player1.getScore() - player2.getScore());
            if (minusResult == 1)
            {
                return "Advantage player1";
            }
            else
            {
                return "Advantage player2";
            }
        }
    }

    class WinResult: Result
    {
        public WinResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
            var minusResult = player1.getScore() - player2.getScore();

            if (minusResult >= 2)
            {
                return "Win for player1";
            }
            else 
            { 
                return "Win for player2"; 
            }
        }
    }
    class EqualityResult : Result
    {
        public EqualityResult(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
            switch (player1.getScore())
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }
    }

}

