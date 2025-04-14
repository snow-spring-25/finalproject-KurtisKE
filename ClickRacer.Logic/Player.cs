public class Player
{
private string name;
public string Name => name;
private int dps;
public int DPS => dps;
private int dpc;
public int DPC => dpc;
private int bank;
public int Bank => bank;
private List<string> driversPurchased; 
public List<string> DriversPurchased => driversPurchased;

public Player(string name)
{
    this.name = name;
    this.dps = 0;
    this.dpc = 1;
    this.bank = 0;
}

}