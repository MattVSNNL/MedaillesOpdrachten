using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Player"))
        {
            return;
        }

        soundManager.PlaySound();
        UI.AddScore();
        print("Item collected");
        Destroy(gameObject);
    }

    [SerializeField] private UIManager UI;
    [SerializeField] private SoundManager soundManager;
}
