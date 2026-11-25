using Unity.Mathematics;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    [SerializeField] private GameObject _spawner;

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (triggered)
            return;

        triggered = true;
        Instantiate(_spawner, new Vector3(-10.82f, -3.39f, 0f), quaternion.identity);
    }
}
