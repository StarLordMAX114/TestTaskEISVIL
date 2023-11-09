using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private PlayerView _playerView;
    private int _currentHealth;
    
    private void Update()
    {
        if (_currentHealth != _playerView.Health)
        {
            _currentHealth = _playerView.Health;
            _text.text = $"HP {_currentHealth}";
        }
    }
}
