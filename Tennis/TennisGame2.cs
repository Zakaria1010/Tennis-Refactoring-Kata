using static System.Formats.Asn1.AsnWriter;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {


        public Player player1;
        public Player player2;

        public TennisGame2(string player1Name, string player2Name)
        {


            this.player1 = new Player(player1Name);
            this.player2 = new Player(player2Name); 
        }

        public string GetScore()
        {
            return FactoryResult.factoryResult(player1, player2).getScoreAsText();
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
            {
                player1.addPoint();
            }
            else
            {
                player2.addPoint();
            }
        }

    }

    public class FactoryResult
    {
        public static Result factoryResult(Player player1, Player player2)
        {
            if (player1.isTieWidth(player2))
            {
                return new EqualGame2Result(player1, player2);
            }
            else if (player1.eitherPlayerHasAdvantage(player2) && player1.someoneIsAheadByOne(player2))
            {
                return new AdvantageGame2Result(player1, player2);
            }
            else if (player1.eitherPlayerHasAdvantage(player2))
            {
                return new WinGame2Result(player1, player2);
            }
            else
            {
                return new OnGoingGame2Result(player1, player2);
            }
        }
    }
    public class AdvantageGame2Result : Result
    {
        public AdvantageGame2Result(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
            string score = "";
            if ( player1.getScore() > player2.getScore() && player2.getScore() >= 3)
            {
                score = "Advantage player1";
            }

            if (player2.getScore() > player1.getScore() && player1.getScore() >= 3)
            {
                score = "Advantage player2";
            }

            return score;
        }
    }

    public class WinGame2Result : Result
    {
        public WinGame2Result(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
            string score = "";
            
            if (player1.getScore() >= 4 && player2.getScore() >= 0 && (player1.getScore() - player2.getScore()) >= 2)
            {
                score = "Win for player1";
            }
            if (player2.getScore() >= 4 && player1.getScore() >= 0 && (player2.getScore() - player1.getScore()) >= 2)
            {
                score = "Win for player2";
            }

            return score;
        }
    }

    public class EqualGame2Result : Result
    {
        public EqualGame2Result(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
            var score = "";
            if (player1.getScore() == player2.getScore() && player1.getScore() < 3)
            {
                if (player1.getScore() == 0)
                    score = "Love";
                if (player1.getScore() == 1)
                    score = "Fifteen";
                if (player1.getScore() == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (player1.getScore() == player2.getScore() && player1.getScore() > 2)
                score = "Deuce";
            return score;
        }
    }

    public class OnGoingGame2Result : Result
    {
        public OnGoingGame2Result(Player player1, Player player2) : base(player1, player2)
        {
        }

        public override string getScoreAsText()
        {
            string score = "";
            if (player1.getScore() > 0 && player2.getScore() == 0)
            {
                if (player1.getScore() == 1)
                    player1.result = "Fifteen";
                if (player1.getScore() == 2)
                    player1.result = "Thirty";
                if (player1.getScore() == 3)
                    player1.result = "Forty";

                player2.result = "Love";
                score = player1.result + "-" + player2.result;
            }
            if (player2.getScore() > 0 && player1.getScore() == 0)
            {
                if (player2.getScore() == 1)
                    player2.result = "Fifteen";
                if (player2.getScore() == 2)
                    player2.result = "Thirty";
                if (player2.getScore() == 3)
                    player2.result = "Forty";

                player1.result = "Love";
                score = player1.result + "-" + player2.result;
            }

            if (player1.getScore() > player2.getScore() && player1.getScore() < 4)
            {
                if (player1.getScore() == 2)
                    player1.result = "Thirty";
                if (player1.getScore() == 3)
                    player1.result = "Forty";
                if (player2.getScore() == 1)
                    player2.result = "Fifteen";
                if (player2.getScore() == 2)
                    player2.result = "Thirty";
                score = player1.result + "-" + player2.result;
            }
            if (player2.getScore() > player1.getScore() && player2.getScore() < 4)
            {
                if (player2.getScore() == 2)
                    player2.result = "Thirty";
                if (player2.getScore() == 3)
                    player2.result = "Forty";
                if (player1.getScore() == 1)
                    player1.result = "Fifteen";
                if (player1.getScore() == 2)
                    player1.result = "Thirty";
                score = player1.result + "-" + player2.result;
            }

            return score;
        }
    }
}

