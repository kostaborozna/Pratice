using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (GameIsOver) return;
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }
    private void EndGame()
    {
        gameOverUI.SetActive(true);
        GameIsOver = true;
    }
}
