using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    public AudioSource _audioSource;
    public float volume=0.5f;
    void Start()
    {
        _audioSource.PlayOneShot(_audioClip, volume);
    }
}
