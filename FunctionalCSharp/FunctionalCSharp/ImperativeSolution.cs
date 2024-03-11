namespace FunctionalCSharp;

public static class ImperativeSolution
{
    public static int MagicSum(IEnumerable<string> items)
    {
        var all = new List<int>();

        using (IEnumerator<string> enumerator = items.GetEnumerator())
        {
            while(enumerator.MoveNext())
            {
                if (int.TryParse(enumerator.Current, out var number)) all.Add(number);
            }
        }

        if (all.Count < 2) return -1;

        int[] greatestTwo = { all[0], all[1] };

        if (greatestTwo[1] > greatestTwo[0])
        {
            greatestTwo[0] = all[1];
            greatestTwo[1] = all[0];
        }

        for (int i = 2; i < all.Count; i++)
        {
            if(all[i] > greatestTwo[0])
            {
                greatestTwo[1] = greatestTwo[0];
                greatestTwo[0] = all[i];
            }
            else if(all[i] > greatestTwo[1])
            {
                greatestTwo[1] = all[i];
            }
        }
        
        return greatestTwo[0] + greatestTwo[1];
    }
}