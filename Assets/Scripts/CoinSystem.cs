using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    void Awake()
    {
        if (_uiManager == null)
            _uiManager = FindAnyObjectByType<UIManager>();

        if (_soundManager == null)
            _soundManager = FindAnyObjectByType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
        {
            return;
        }

        _soundManager.PlaySound();
        _uiManager.AddScore();
        print("Item collected");
        Destroy(gameObject);
    }

    [SerializeField] private UIManager _uiManager;
    [SerializeField] private SoundManager _soundManager;
}
