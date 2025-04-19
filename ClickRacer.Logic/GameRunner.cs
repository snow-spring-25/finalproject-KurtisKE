namespace ClickRacer.Logic;

public class GameRunner
{
    public Player Player { get; set; }

    public List<IUpgrade> Sponsers { get; } = new()
    {
        new ClickUpgrade { Name = "RedBull", Cost = 10, Bonus = 1 },
        new ClickUpgrade { Name = "Google", Cost = 50, Bonus = 5 },
        new ClickUpgrade { Name = "DHL", Cost = 100, Bonus = 20 },
        new ClickUpgrade { Name = "Cigarettes", Cost = 500, Bonus = 50 },
        new ClickUpgrade { Name = "Crypto.com", Cost = 7500, Bonus = 100 },
        new ClickUpgrade { Name = "Stake", Cost = 50000, Bonus = 25000 },
        new ClickUpgrade { Name = "Secret win button", Cost = 10, Bonus = 100000 }
    };

    static public List<Driver> AvailableDrivers { get; } = new()
    {
    new Driver { Name = "Lando Norris", Cost = 29000000, SkillLevel = 5 },
    new Driver { Name = "Oscar Piastri", Cost = 23000000, SkillLevel = 5 },
    new Driver { Name = "Max Verstappen", Cost = 28400000, SkillLevel = 5 },
    new Driver { Name = "George Russell", Cost = 21000000, SkillLevel = 4 },
    new Driver { Name = "Charles Leclerc", Cost = 25900000, SkillLevel = 4 },
    new Driver { Name = "Kimi Antonelli", Cost = 18400000, SkillLevel = 3 },
    new Driver { Name = "Lewis Hamilton", Cost = 24200000, SkillLevel = 5 },
    new Driver { Name = "Alexander Albon", Cost = 12000000, SkillLevel = 3 },
    new Driver { Name = "Esteban Ocon", Cost = 7300000, SkillLevel = 3 },
    new Driver { Name = "Lance Stroll", Cost = 8100000, SkillLevel = 1 },
    new Driver { Name = "Pierre Gasly", Cost = 11800000, SkillLevel = 3 },
    new Driver { Name = "Nico Hulkenberg", Cost = 6400000, SkillLevel = 3 },
    new Driver { Name = "Oliver Bearman", Cost = 6700000, SkillLevel = 3 },
    new Driver { Name = "Yuki Tsunoda", Cost = 9600000, SkillLevel = 3 },
    new Driver { Name = "Isack Hadjar", Cost = 6200000, SkillLevel = 1 },
    new Driver { Name = "Carlos Sainz", Cost = 13100000, SkillLevel = 5 },
    new Driver { Name = "Fernando Alonso", Cost = 8800000, SkillLevel = 4 },
    new Driver { Name = "Liam Lawson", Cost = 18000000, SkillLevel = 2 },
    new Driver { Name = "Jack Doohan", Cost = 7200000, SkillLevel = 1 },
    new Driver { Name = "Gabriel Bortoleto", Cost = 6000000, SkillLevel = 1 },
    };
    
    public void StartGame(string name)
    {
        Player = new Player(name);
    }

    public void Click() => Player?.Click();
    public void BuyUpgrade(ClickUpgrade upgrade) => Player?.BuyUpgrade(upgrade);

 public bool TryBuyDriver(string driverName)
    {
        var driver = AvailableDrivers.FirstOrDefault(d => d.Name == driverName);
        if (driver != null && Player.Money >= driver.Cost)
        {
            Player.Money -= driver.Cost;
            Player.TeamDrivers.Add(driver);
            AvailableDrivers.Remove(driver);
            return true;
        }
        return false;
    }
}
