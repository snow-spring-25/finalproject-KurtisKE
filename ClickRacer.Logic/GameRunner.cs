namespace ClickRacer.Logic;

public class GameRunner
{
    public Player Player { get; set; }

    public List<IUpgrade> Sponsers { get; } = new()
    {
        new ClickUpgrade { Name = "cheat", Cost = 1, Bonus = 9999999 },
        new ClickUpgrade { Name = "RedBull", Cost = 100, Bonus = 1 },
        new ClickUpgrade { Name = "Google", Cost = 175, Bonus = 2 },
        new ClickUpgrade { Name = "DHL", Cost = 306, Bonus = 4 },
        new ClickUpgrade { Name = "Pirelli", Cost = 536, Bonus = 7 },
        new ClickUpgrade { Name = "Petronas", Cost = 938, Bonus = 12 },
        new ClickUpgrade { Name = "Aramco", Cost = 1641, Bonus = 20 },
        new ClickUpgrade { Name = "Rolex", Cost = 2872, Bonus = 33 },
        new ClickUpgrade { Name = "Emirates", Cost = 5027, Bonus = 50 },
        new ClickUpgrade { Name = "Ferrari World", Cost = 8798, Bonus = 75 },
        new ClickUpgrade { Name = "INEOS", Cost = 15397, Bonus = 110 },
        new ClickUpgrade { Name = "Amazon Web Services", Cost = 26945, Bonus = 160 },
        new ClickUpgrade { Name = "Heineken", Cost = 47154, Bonus = 225 },
        new ClickUpgrade { Name = "Lenovo", Cost = 82519, Bonus = 300 },
        new ClickUpgrade { Name = "Stake", Cost = 144409, Bonus = 400 },
        new ClickUpgrade { Name = "Crypto.com", Cost = 252716, Bonus = 525 },
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
    public List<PassiveUpgrade> PassiveUpgrades = new()
    {
    new PassiveUpgrade { Name = "Funny Commercials", Cost = 50, Bonus = 1 },
    new PassiveUpgrade { Name = "Instagram Reels", Cost = 120, Bonus = 2 },
    new PassiveUpgrade { Name = "Netflix Special", Cost = 300, Bonus = 5 },
    new PassiveUpgrade { Name = "Behind the Scenes Vlog", Cost = 750, Bonus = 10 },
    new PassiveUpgrade { Name = "Branded Merch", Cost = 1500, Bonus = 20 },
    new PassiveUpgrade { Name = "Driver TikTok Challenge", Cost = 3000, Bonus = 35 },
    new PassiveUpgrade { Name = "YouTube Documentary", Cost = 5000, Bonus = 50 },
    new PassiveUpgrade { Name = "Fan Meet & Greet", Cost = 9000, Bonus = 75 },
    new PassiveUpgrade { Name = "Podcast Sponsorships", Cost = 13000, Bonus = 100 },
    new PassiveUpgrade { Name = "Virtual Pit Crew Simulator", Cost = 18000, Bonus = 150 },
    new PassiveUpgrade { Name = "Official EA F1 Game Collab", Cost = 25000, Bonus = 200 },
    new PassiveUpgrade { Name = "Racing Highlights", Cost = 35000, Bonus = 300 },
    new PassiveUpgrade { Name = "Esports Team Launch", Cost = 50000, Bonus = 500 },
    new PassiveUpgrade { Name = "Brand NFT Collection", Cost = 80000, Bonus = 750 },
    new PassiveUpgrade { Name = "Global Fan Club Membership", Cost = 100000, Bonus = 1000 }
    };

    public void StartGame(string name)
    {
        Player = new Player(name);
    }

    public void Click() => Player?.Click();
    public void BuyUpgrade(ClickUpgrade upgrade) => Player?.BuyUpgrade(upgrade); //(REQ#1.2.3)

    public bool TryBuyDriver(string driverName)//(REQ#1.1.3)
    {
        if (Player.TeamDrivers.Count >= 2)//only get two
        return false;

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

    public void AddPassiveIncome()
    {
        if (Player != null)
        {
            Player.AddPassiveIncome();
        }
    }

    public void BuyPassiveUpgrade(PassiveUpgrade upgrade)
    {
        if (Player != null && Player.Money >= upgrade.Cost)
        {
            Player.Money -= upgrade.Cost;
            Player.PassiveIncomePerSecond += upgrade.Bonus;
            PassiveUpgrades.Remove(upgrade);
        }
    }

    



}
