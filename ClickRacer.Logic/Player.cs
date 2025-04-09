public class Player
{
private string name;
public string Name => name;
private int DPS;
private int DPC;
private int Bank;

public Player(string name)
{
    this.name = name;
    this.DPS = 0;
    this.DPC = 1;
    this.Bank = 0;
}
}