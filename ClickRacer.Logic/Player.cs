public class Player
{
private string name;
public string Name => name;
private int dps;
public int DPS => dps;
private int dpc;
private int Bank;

public Player(string name)
{
    this.name = name;
    this.dps = 0;
    this.dpc = 1;
    this.Bank = 0;
}
}