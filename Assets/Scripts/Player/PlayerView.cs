using UnityEngine;

public sealed class PlayerView : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeReference] private FixedJoystick _joystick;

    [Header("Инвентарь")]
    [Tooltip("Оружие")]
    [SerializeField] private Weapon _playerWeapon;
    
    [Header("Характеристики игрока")]
    
    [Tooltip("Скорость")]
    [Range(1,10)] public int Speed;
    
    [Tooltip("Здоровье")]
    [Range(1,10)] public int Health;

    public Rigidbody PlayerRigidbody => _playerRigidbody;
    public FixedJoystick Joystick => _joystick;

    public Weapon PlayerWeapon => _playerWeapon;
    
}
