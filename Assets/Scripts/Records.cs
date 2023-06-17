using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class Records : MonoBehaviour
{
    public TextMeshProUGUI gamesCount;

    public TextMeshProUGUI moneyCount;

    public TextMeshProUGUI enemyCount;

    private int enemyKilsCounter;

    private int gamesCounter;

    private int moneyCounter;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Kils") == 0 || PlayerPrefs.GetInt("Games") == 0 || PlayerPrefs.GetInt("Money") == 0)
            return;
        Kils();
        Games();
        Money();
    }

    private void OnApplicationQuit()
    {
        int countKils = Convert.ToInt32(enemyCount.text);
        PlayerPrefs.SetInt("Kils_Old", countKils);


        int countGames = Convert.ToInt32(gamesCount.text);
        PlayerPrefs.SetInt("Games_Old", countGames);

        int money = Convert.ToInt32(moneyCount.text);
        PlayerPrefs.SetInt("Money_Old", money);


        PlayerPrefs.Save();
    }

    private void Kils()
    {
        enemyKilsCounter = Convert.ToInt32(enemyCount.text);
        enemyKilsCounter = PlayerPrefs.GetInt("Kils") + PlayerPrefs.GetInt("Kils_Old");
        enemyCount.text = enemyKilsCounter.ToString();
    }

    private void Games()
    {
        gamesCounter = Convert.ToInt32(gamesCount.text);
        gamesCounter = PlayerPrefs.GetInt("Games") + PlayerPrefs.GetInt("Games_Old");
        gamesCount.text = gamesCounter.ToString();
    }


    private void Money()
    {
        moneyCounter = Convert.ToInt32(moneyCount.text);
        moneyCounter = PlayerPrefs.GetInt("Money") + PlayerPrefs.GetInt("Money_Old");
        moneyCount.text = moneyCounter.ToString();
    }

    public void DellInfo()
    {
        PlayerPrefs.DeleteAll();
        Kils();
        Games();
        Money();
    }


}
