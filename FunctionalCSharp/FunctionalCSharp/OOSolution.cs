namespace FunctionalCSharp;

public static class OOSolution
{
    public static int MagicSum(IEnumerable<string> items)
    {
        List<int> all = new (100);
        foreach (string item in items)
        {
            if (int.TryParse(item, out var number)) all.Add(number);
        }
        
        if(all.Count < 2) return -1;
        
        var (a, b) = all[0] >= all[1] ? (all[0], all[1]) : (all[1], all[0]);
        
        foreach(int number in all.Skip(2))
        {
            if(number > a) (a, b) = (number, a);
            else if(number > b) b = number;
        }

        return a + b;
    }
    
    
}