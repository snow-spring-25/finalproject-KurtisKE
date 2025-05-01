
using ClickRacer.Logic;

public class RaceManager
{
    private List<SubmittedDriver> submittedDrivers = new();
    private string lastResult = "";
    private DateTime nextRaceTime = DateTime.UtcNow.AddMinutes(2);

    public IReadOnlyList<SubmittedDriver> SubmittedDrivers => submittedDrivers.AsReadOnly();
    public string LastResult => lastResult;
    public DateTime NextRaceTime => nextRaceTime;

    public void SubmitDriver(Player player, Driver driver)
    {
        if (!submittedDrivers.Any(s => s.Driver == driver))
        {
            submittedDrivers.Add(new SubmittedDriver { Driver = driver, Owner = player });
        }
    }
    public List<string> GetSubmittedDriverNames()
    {
        return SubmittedDrivers
            .Select(s => $"{s.Driver.Name} (Team {s.Owner.Name})")
            .ToList();
    }

    public bool IsDriverSubmitted(Driver driver) => submittedDrivers.Any(d => d.Driver == driver);

    public string RunRace()
    {
        if (submittedDrivers.Count < 2)
        {
            lastResult = "Not enough drivers submitted!";
        }
        else
        {
            var winner = submittedDrivers
                .OrderByDescending(entry => entry.Driver.SkillLevel + Random.Shared.Next(0, 10))
                .First();

            winner.Owner.Money += 1000000;
            lastResult = $"{winner.Driver.Name} (Team {winner.Owner.Name}) wins!";
        }

        submittedDrivers.Clear();
        nextRaceTime = DateTime.UtcNow.AddMinutes(2);
        return lastResult;
    }
}

public class SubmittedDriver
{
    public Driver Driver { get; set; } = null!;
    public Player Owner { get; set; } = null!;
}