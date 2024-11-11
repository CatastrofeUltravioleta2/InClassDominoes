public class Game
{
    public GameStatus Status {get; private set;}
    public string Name {get;set;}
    public int NumberOfPlayer{get;set;}
    public Game()
    {
        Status = GameStatus.Not_Started;
    }
}
