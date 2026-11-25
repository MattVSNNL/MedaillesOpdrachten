using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public void AddScore()
    {
        _score += 1;
        _scoreText.text = _score.ToString();
    }

    private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;
}
