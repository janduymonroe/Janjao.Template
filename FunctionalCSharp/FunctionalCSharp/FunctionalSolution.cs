namespace FunctionalCSharp;

public static class FunctionalSolution
{
    public static int MagicSum(IEnumerable<string> items) => 
        items.Aggregate((max:0, next:0, count:0), AdvancedRaw, ProduceSum);
    
    private static int ProduceSum((int max, int next, int count) tuple) => 
        tuple.count == 2 ? tuple.max + tuple.next : -1;

    private static (int max, int next, int count) AdvancedRaw((int max, int next, int count) tuple, string item) =>
        int.TryParse(item, out var number) ? Advanced(tuple, number) : tuple;

    private static (int max, int next, int count) Advanced((int max, int next, int count) tuple, int number) => tuple switch
    {
        (_, _, 0) => (number, 0, 1),
        (var max, _, 1) when number > max => (max, number, 2),
        (var max, _, 1) => (max, number, 2),
        (var max, _, 2) when number > max => (number, max, 2),
        (var max, var next, 2) when number > next => (max, number, 2),
        _ => tuple
    };
}