using UnityEngine;

public sealed class PlayerController
{
    private PlayerView _playerView;
    private Rigidbody _rigidbody;
    private FixedJoystick _joystick;

    private float _distance;
    
    public PlayerController(PlayerView playerView)
    {
        _playerView = playerView;
        _rigidbody = _playerView.PlayerRigidbody;
        _joystick = _playerView.Joystick;
    }

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _playerView.Speed, _rigidbody.velocity.y, _joystick.Vertical * _playerView.Speed);
        if (_playerView.Joystick.Horizontal != 0 || _playerView.Joystick.Vertical != 0)
        {
            _playerView.transform.rotation = Quaternion.LookRotation(_playerView.PlayerRigidbody.velocity);
        }
    }
}
