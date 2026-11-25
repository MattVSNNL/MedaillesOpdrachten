using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private AudioClip _winnerSound;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayPickupSound()
    {
        _audioSource.PlayOneShot(_pickupSound);
    }

    public void PlayWinnerSound()
    {
        _audioSource.PlayOneShot(_winnerSound);
    }

}
