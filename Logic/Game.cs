public class Game
{
    public GameStatus Status { get; private set; }
    public string Name { get; set; }
    public int NumberOfPlayer { get; set; }


    public static Game Instance { get; private set; } = new Game();
    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }
    public List<Tile> Board { get; private set; }
    public bool NoOneCanPlay
    {
        get
        {
            if (Player1 is null || Player2 is null)
                return false;

            var player1CanPlay = Player1.HasMatchFor(Board.Last());
            var player2CanPlay = Player2.HasMatchFor(Board.Last());
            return !player1CanPlay && !player2CanPlay;
        }
    }
    public Game()
    {
        Status = GameStatus.Not_Started;
    }
}
