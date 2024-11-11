public static class Lobby
{
    static public List<Game> Games {get;} = new List<Game>();
    public static event Action? GameListChanged;

}