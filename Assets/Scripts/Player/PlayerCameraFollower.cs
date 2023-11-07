using UnityEngine;

public sealed class PlayerCameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    private Transform _cameraTransform;
    private float _offset = 15;

    private void Awake()
    {
        _cameraTransform = gameObject.transform;
    }
    
    private void Update()
    {
        gameObject.transform.position = new Vector3(_cameraTransform.position.x, _cameraTransform.position.y, _playerTransform.position.z - _offset);
    }
}
