using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private int _score;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void AddScore()
    {
        _score += 1;
        _scoreText.text = _score.ToString();
    }

}
