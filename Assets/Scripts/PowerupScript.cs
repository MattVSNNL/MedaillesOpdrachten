using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private float _powerupSpeed;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private UIManager _UI;
    private bool _collected = false;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (_collected)
            return;

        _collected = true;
        sprite.enabled = false;
        StartCoroutine(SetSpeedFunction());
    }

    IEnumerator SetSpeedFunction()
    {
        _playerMovement.SetSpeed(_powerupSpeed);
        print("Here");
        _UI.StartPowerupTimer(10);
        yield return new WaitForSeconds(10);
        print("Here 2");
        _playerMovement.SetSpeed(5f);
        Destroy(gameObject);
    }
}
