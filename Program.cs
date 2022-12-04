using AdventOfCode2022.Common;

var mostRecentDay = Activator.CreateInstance(
    typeof(BaseDay).Assembly.GetTypes()
                   .Where(t => t.IsSubclassOf(typeof(BaseDay)))
                   .OrderByDescending(t => int.Parse(t.Name[3..]))
                   .First()) as BaseDay;

mostRecentDay!.TestFirstPart();
mostRecentDay.ExecuteFirstPart();
mostRecentDay.TestSecondPart();
mostRecentDay.ExecuteSecondPart();