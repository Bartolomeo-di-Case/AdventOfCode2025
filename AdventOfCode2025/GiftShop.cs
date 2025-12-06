namespace AdventOfCode2025;

public class GiftShop
{
    private long result = 0;

    private const string ExampleInput =
        "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

    private const string MyInput =
        "959516-995437,389276443-389465477,683-1336,15687-26722,91613-136893,4-18,6736-12582,92850684-93066214,65-101,6868676926-6868700146,535033-570760,826141-957696,365650-534331,1502-2812,309789-352254,79110404-79172400,18286593-18485520,34376-65398,26-63,3333208697-3333457635,202007-307147,1859689-1936942,9959142-10053234,2318919-2420944,5142771457-5142940464,1036065-1206184,46314118-46413048,3367-6093,237-481,591751-793578";

    public long GetResultPartOne()
    {
        string[] parts = MyInput.Split(',');

        foreach (string part in parts)
        {
            string[] startAndEnd = part.Split('-');
            long start = long.Parse(startAndEnd[0]);
            long end = long.Parse(startAndEnd[1]);

            for (long i = start; i <= end; i++)
            {
                string iAsAsString = i.ToString();
                
                // uneven numbers are never invalid
                if (iAsAsString.Length % 2 == 1) continue;
                
                int midIndex = iAsAsString.Length / 2;

                if (iAsAsString[..midIndex] == iAsAsString[midIndex..]) result += i;
            }
        }
        
        return result;
    }
    
    public long GetResultPartTwo()
    {
        string[] parts = MyInput.Split(',');

        foreach (string part in parts)
        {
            string[] startAndEnd = part.Split('-');
            long start = long.Parse(startAndEnd[0]);
            long end = long.Parse(startAndEnd[1]);

            for (long i = start; i <= end; i++)
            {
                string iAsAsString = i.ToString();

                if (HasInvalidId(iAsAsString)) result += i;
            }
        }
        
        return result;
    }

    public static bool HasInvalidId(string input)
    {
        for (int i = 1; i <= input.Length / 2; i++)
        {
            List<char[]> chunks = input.Chunk(i).ToList();
            
            if (chunks.All(chunk => chunk.SequenceEqual(chunks[0]))) return true;
        }

        return false;
    }
}