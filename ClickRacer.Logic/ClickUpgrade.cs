namespace ClickRacer.Logic;
public interface IUpgrade
{
    string Name { get; set; }
    int Cost { get; set; }
    int Bonus { get; set; }
}

public class ClickUpgrade : IUpgrade
{
    public string Name { get; set; } = "";
    public int Cost { get; set; }
    public int Bonus { get; set; }
    public ClickUpgrade(){}
}

public class MultUpgrade : IUpgrade
{
    public string Name { get; set; } = "";
    public int Cost { get; set; }
    public int Bonus { get; set; }
    public MultUpgrade(){}
}

public class PassiveUpgrade : IUpgrade
{
    public string Name { get; set; } = "";
    public int Cost { get; set; }
    public int Bonus { get; set; }
    public PassiveUpgrade(){}
}


