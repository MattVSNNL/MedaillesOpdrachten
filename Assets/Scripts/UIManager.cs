using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();
    }

    private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
}
