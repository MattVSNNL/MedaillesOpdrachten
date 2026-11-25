using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerScript : MonoBehaviour
{

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            float angle = i * (360 / 5f) * Mathf.Rad2Deg;
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, 0f) * radius;

            Instantiate(Coin, transform.position + offset, quaternion.identity);
        }
    }

    [SerializeField] private GameObject Coin;
    private float radius = 2f;
}
