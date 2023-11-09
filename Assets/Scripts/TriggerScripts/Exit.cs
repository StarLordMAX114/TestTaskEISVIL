using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private AudioSource _audioSource;
    private Reference _reference;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _reference = new Reference();
            Instantiate(_reference.U_WIN, _canvas.transform);
            _audioSource.Stop();
            Time.timeScale = 0;
        }
    }
}
