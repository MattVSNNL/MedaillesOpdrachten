using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnerScript : MonoBehaviour
{

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(_coin, transform.position + new Vector3(i * _spacing, 0f, 0f), quaternion.identity);
        }
    }

    [SerializeField] private GameObject _coin;
    private float _radius = 2f;
    private float _spacing = 1f;
    private float _coinAmount = 5f;
}
