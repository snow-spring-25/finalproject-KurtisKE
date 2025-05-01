namespace ClickRacer.Logic;
public class Player
{
    public string Name { get; set; }
    public int Money { get; set; } 
    public int ClickValue { get; private set; } = 1;
    public List<Driver> TeamDrivers { get; set; } = new();
    public int PassiveIncomePerSecond { get; set; } = 1;
    public void AddPassiveIncome() => Money += PassiveIncomePerSecond;
    public Player(string name)
    {
        Name = name;
    }

    public void Click()
    {
        Money += ClickValue;
    }

    public void BuyUpgrade(ClickUpgrade upgrade)
    {
        if (Money >= upgrade.Cost)
        {
            Money -= upgrade.Cost;
            ClickValue += upgrade.Bonus;
        }
    }

    public void BuyMultUpgrade(ClickUpgrade upgrade)
    {
        if (Money >= upgrade.Cost)
        {
            Money -= upgrade.Cost;
            ClickValue *= upgrade.Bonus;
        }
    }
}