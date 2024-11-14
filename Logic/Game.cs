using System.Security.AccessControl;

public class Game
{
    public GameStatus Status { get; private set; }
    public string Name { get; set; }
    public int NumberOfPlayer { get; set; }


    public static Game Instance { get; private set; } = new Game();
    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }
    public List<Tile> Board { get; private set; }
    public bool IsGameOver
    {
        get
        {
            if (Player1 == null || Player2 == null)
            {
                return false;
            }
            if (Player1.Tiles.Count == 0 || Player2.Tiles.Count == 0 || NoOneCanPlay)
            {
                return true;
            }
            return false;
        }
    }
    public bool IsPlayable
    {
        get
        {
            if (Player1 != null && Player2 != null && !IsGameOver)
            {
                return true;
            }
            return false;
        }
    }
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
    public event Action? GameReset;
    public event Action? GameStateChanged;

    public Game()
    {
        Reset();
        Status = GameStatus.Not_Started;
    }

    public void Reset()
    {
        Player1 = null;
        Player2 = null;
        Board = new List<Tile> { new Tile(1, 1) };
        GameReset?.Invoke();
    }

    public void Join(Player player)
    {
        if (Player1 is null)
        {
            Player1 = player;
        }
        else if (Player2 is null)
        {
            Player2 = player;
        }
        else
        {
            throw new Exception();//GameFullException();
        }
        GameStateChanged?.Invoke();
    }
}
