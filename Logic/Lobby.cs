namespace Lab12Logic;
public static class Lobby
{
    static public List<Game> Games {get;} = new List<Game>();
    public static event Action? GameListChanged;
    public static void RunGameListChangedEvent()
    {
        GameListChanged?.Invoke();
    }

}