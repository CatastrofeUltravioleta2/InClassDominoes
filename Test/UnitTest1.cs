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
    public void NewGameInstanceIsPNotlayable()
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
    [Fact]
    public void PlayTileOnBoard()
    {
        Game testGame = new Game();
        testGame.Join(new Player("test1"));
        testGame.Join(new Player("test2"));
        var tileToPlay = new Tile(1, testGame.Board.First().Num1);
        testGame.Player1.Tiles.Add(tileToPlay);
        testGame.PlayTile(testGame.Player1, testGame.Player1.Tiles.Last());
        testGame.Board.Count.Should().Be(2);
        testGame.Board.Last().Equals(tileToPlay).Should().BeTrue();
    }
    [Fact]
    public void PlayTileNotInPlayerOnBoard()
    {
        Game testGame = new Game();
        testGame.Join(new Player("test1"));
        testGame.Join(new Player("test2"));
        var tileToPlay = new Tile(1, testGame.Board.First().Num1);
        testGame.Invoking(_ => testGame.PlayTile(testGame.Player1, testGame.Player1.Tiles.Last())).Should().Throw<InvalidMoveException>();
    }
    [Fact]
    public void Player1Wins()
    {
        var game = new Game();
        var player1 = new Player("P1", 7);
        var player2 = new Player("P2", 7);
        game.Join(player1);
        game.Join(player2);

        player1.Tiles.Clear();
        player1.Tiles.Add(new Tile(1, 2));
        player1.Tiles.Add(new Tile(2, 3));
        player1.Tiles.Add(new Tile(3, 4));
        var expectedBoardLength = 1 + player1.Tiles.Count;

        while (player1.Tiles.Any())
        {
            game.PlayTile(player1, player1.Tiles.First());
        }

        game.Board.Count.Should().Be(expectedBoardLength);
        game.IsPlayable.Should().BeFalse();
        game.Winner.Should().Be(player1);
        game.IsGameOver.Should().BeTrue();
    }


}
