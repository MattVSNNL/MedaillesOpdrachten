using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerScript : MonoBehaviour
{

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(Coin, transform.position + new Vector3(i * spacing, 0f, 0f), quaternion.identity);
        }
    }

    [SerializeField] private GameObject Coin;
    private float radius = 2f;
    private float spacing = 1f;
    private float coinAmount = 5f;
}
