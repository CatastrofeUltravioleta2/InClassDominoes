using FluentAssertions;

namespace Test;

public class UnitTest1
{
    [Fact]
    public void OppositeTilesAreEqual()
    {
        var t1 = new Tile(1, 2);
        var t2 = new Tile(2, 1);
        t1.Equals(t2).Should().BeTrue();
    }

    [Fact]
    public void NewGameInstanceFalse()
    {
        Game testGame = new Game();
        testGame.IsGameOver.Should().Be(false);
    }
    [Fact]
    public void NewGameInstanceIsPlayable()
    {
        Game testGame = new Game();
        testGame.IsPlayable.Should().Be(false);
    }
    [Fact]
    public void JoinOnePlayer()
    {
        Game testGame = new Game();
        testGame.Join(new Player("test1"));
        testGame.IsPlayable.Should().Be(false);
    }  
    [Fact]
    public void JoinTwoPlayers()
    {
        Game testGame = new Game();
        testGame.Join(new Player("test1"));
        testGame.Join(new Player("test2"));
        testGame.IsPlayable.Should().Be(true);
        testGame.IsGameOver.Should().Be(false);
    }  


}
