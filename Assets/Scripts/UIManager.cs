using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private int _score;
    private int _streak;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private SoundManager _soundManager;

    void Awake()
    {
        if (_soundManager == null)
            _soundManager = FindAnyObjectByType<SoundManager>();
    }

    public void AddScore()
    {
        _score += 1;
        _streak += 1;
        _scoreText.text = _score.ToString();

        if (_streak >= 5)
        {
            _streak = 0;
            _soundManager.PlayWinnerSound();
        }
    }

}
