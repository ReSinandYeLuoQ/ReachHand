using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance { get; private set; }
    public OrderData OrderData { get; private set; }

    public static void Initialize()
    {
        if (Instance == null)
        {
            GameObject manager = new GameObject("GameDataManager");
            Instance = manager.AddComponent<GameDataManager>();
            DontDestroyOnLoad(manager);
        }
    }

    public void InitializeOrder(int setCount)
    {
        OrderData = new OrderData(setCount);
    }

    public void AddRandomNumbers(List<int> numbers)
    {
        OrderData.AddRandomNumbers(numbers);
    }
}