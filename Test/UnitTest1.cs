﻿using FluentAssertions;

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
}
