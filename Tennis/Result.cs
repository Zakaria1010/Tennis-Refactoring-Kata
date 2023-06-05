namespace Tennis
{
    public abstract class Result
    {
        public Player player1;
        public Player player2;

        public Result(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public abstract string getScoreAsText();
    }

}

