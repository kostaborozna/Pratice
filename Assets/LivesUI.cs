using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    private void Update()
    {
        livesText.text = "Çהמנמגüו: " + PlayerStats.Lives.ToString();
    }
}
