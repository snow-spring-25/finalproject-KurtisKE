namespace ClickRacer.Test;
using ClickRacer.Logic;
using Shouldly;
public class Test1
{
    [SetUp]
    public void Setup()//this makes all the tests start the same
    {
        GameRunner.AvailableDrivers.Clear();
        GameRunner.AvailableDrivers.AddRange(new[]
        {
                new Driver { Name = "Max Verstappen", Cost = 1000, SkillLevel = 5 },
                new Driver { Name = "Lando Norris", Cost = 500, SkillLevel = 4 }
            });
    }

    [Test]
    public void BuyDriverShouldPAss()//(REQ#1.1.1)
    {
        var game = new GameRunner();
        game.StartGame("TestPlayer");
        game.Player.Money = 1500;

        var result = game.TryBuyDriver("Lando Norris");

        result.ShouldBeTrue();
        game.Player.TeamDrivers.Count.ShouldBe(1);
        game.Player.TeamDrivers[0].Name.ShouldBe("Lando Norris");
        game.Player.Money.ShouldBe(1000);
        GameRunner.AvailableDrivers.Any(d => d.Name == "Lando Norris").ShouldBeFalse();
    }

    [Test]
    public void CantBuyDriverShouldFail()//(REQ#1.1.2)
    {
        var game = new GameRunner();
        game.StartGame("TestPlayer");
        game.Player.Money = 200;

        var result = game.TryBuyDriver("Max Verstappen");

        result.ShouldBeFalse();
        game.Player.TeamDrivers.ShouldBeEmpty();
        GameRunner.AvailableDrivers.Count.ShouldBe(2);
    }

    [Test]
    public void CantBuyHiredDriverShouldFail()
    {
        var game = new GameRunner();
        game.StartGame("TestPlayer");
        game.Player.Money = 5000;

        var result = game.TryBuyDriver("Fernando Alonso");

        result.ShouldBeFalse();
        game.Player.TeamDrivers.ShouldBeEmpty();
        GameRunner.AvailableDrivers.Count.ShouldBe(2);
    }

    [Test]
    public void BuyDriverRemovesFromList()
    {
        var game = new GameRunner();
        game.StartGame("TestPlayer");
        game.Player.Money = 10000;

        game.TryBuyDriver("Max Verstappen");

        GameRunner.AvailableDrivers.Any(d => d.Name == "Max Verstappen").ShouldBeFalse();
    }

    [Test]
    public void BuyMultipleDrivers()
    {
        var game = new GameRunner();
        game.StartGame("TestPlayer");
        game.Player.Money = 5000;

        game.TryBuyDriver("Lando Norris");
        game.TryBuyDriver("Max Verstappen");

        game.Player.TeamDrivers.Count.ShouldBe(2);
        game.Player.TeamDrivers.Any(d => d.Name == "Lando Norris").ShouldBeTrue();
        game.Player.TeamDrivers.Any(d => d.Name == "Max Verstappen").ShouldBeTrue();
    }
}

public class ClickTests2
{
    [Test]
    public void ClickOnceIncreaseMoneyByClickValue() //(REQ#1.2.1)
    {
        var player = new Player("TestPlayer");
        var initialMoney = player.Money;

        player.Click();

        player.Money.ShouldBe(initialMoney + 1);
    }

    [Test]
    public void ClickSeveralTimesShouldGainMoney()
    {
        var player = new Player("TestPlayer");
        var initialMoney = player.Money;

        player.Click();
        player.Click();
        player.Click();

        player.Money.ShouldBe(initialMoney + 3);
    }

    [Test]
    public void ClickValueIncreasesAfterUpgrade()
    {
        var player = new Player("TestPlayer");
        var upgrade = new ClickUpgrade { Name = "BadNAme", Cost = 100, Bonus = 2 };
        player.Money = 50000000;

        player.BuyUpgrade(upgrade);
        player.Click();

        player.Money.ShouldBe(50000000 - 100 + 3);
    }

    [Test]
    public void ClickGetsNewClickValue()
    {
        var player = new Player("TestPlayer");
        var upgrade2 = new ClickUpgrade { Name = "LittleBoost", Cost = 1000, Bonus = 4 };
        player.Money = 50000000;

        player.BuyUpgrade(upgrade2);
        player.Click(); 
        player.Click();

        player.ClickValue.ShouldBe(5);
    }
}
