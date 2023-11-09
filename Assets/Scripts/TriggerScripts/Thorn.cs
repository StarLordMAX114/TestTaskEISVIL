using System.Collections;
using UnityEngine;

public class Thorn : MonoBehaviour
{
    private PlayerView _playerView;
    [Tooltip("Урон")]
    [SerializeField] private int _damage;

    private bool _onTrigger;
    private bool _isTakeDamage = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerView = other.gameObject.GetComponent<PlayerView>();
            _onTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _onTrigger = false;
        }
    }

    private void Update()
    {
        if (_onTrigger & _isTakeDamage)
        {
            StartCoroutine(PlayerTakeDamage(_playerView));
        }
        else if(_onTrigger == false & _isTakeDamage == false)
        {
            StopCoroutine(PlayerTakeDamage(_playerView));
        }
    }

    private IEnumerator PlayerTakeDamage(PlayerView _playerView)
    {
        _isTakeDamage = false;
        
        _playerView.Health -= _damage;
        yield return new WaitForSeconds(1F);
        
        _isTakeDamage = true;
    }
}
