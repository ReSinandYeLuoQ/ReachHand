using System.Collections.Generic;

public class OrderData
{
    private List<int>[] allRandomNumbers;
    private int currentIndex = 0;

    public OrderData(int setCount)
    {
        allRandomNumbers = new List<int>[setCount];
    }

    public void AddRandomNumbers(List<int> numbers)
    {
        if (currentIndex < allRandomNumbers.Length)
        {
            allRandomNumbers[currentIndex] = numbers;
            currentIndex++;
        }
    }

    public List<int> GetRandomNumbers(int setIndex)
    {
        if (setIndex >= 0 && setIndex < allRandomNumbers.Length)
        {
            return allRandomNumbers[setIndex];
        }
        return null;
    }

    public int GetSetCount()
    {
        return allRandomNumbers.Length;
    }
}