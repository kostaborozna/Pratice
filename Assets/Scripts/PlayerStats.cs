
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int gamesCount;
    public static int moneyCount;
    public static int Money;
    public int startMoney = 500;

    public static int Lives;
    public int startLives = 20;

    public static int kils;
    public static int Rounds;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
        kils = 0;
        gamesCount = 0;
        moneyCount = 0;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Kils", kils);
        PlayerPrefs.SetInt("Games", gamesCount);
        PlayerPrefs.SetInt("Money", moneyCount);
        PlayerPrefs.Save();
    }


}
