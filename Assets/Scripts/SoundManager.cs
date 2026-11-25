using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_pickupSound);
    }

    [SerializeField] private AudioClip _pickupSound;
    private AudioSource _audioSource;

}
