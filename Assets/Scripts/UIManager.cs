using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private int _score;
    private int _streak;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _powerupText;
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

    public void StartPowerupTimer(int time)
    {
        StartCoroutine(PowerupCountdown(time));
    }

    IEnumerator PowerupCountdown(int time)
    {
        print("Started");

        _powerupText.gameObject.SetActive(true);
        _powerupText.enabled = true;
        for (int i = time; i > 0; i--)
        {
            _powerupText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        _powerupText.gameObject.SetActive(false);
    }

}
