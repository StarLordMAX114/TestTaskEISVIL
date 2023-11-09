using UnityEngine;
using UnityEngine.AI;

public sealed class EnemyView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    
    [Header("Инвентарь")]
    [Tooltip("Оружие")]
    [SerializeField] private Weapon _enemyWeapon;

    [Header("Характеристики AI")]
    
    [Tooltip("Скорость")]
    [Range(1,10)] public int Speed;
    
    [Tooltip("Дальность передвижения")]
    [Range(1,20)] public float RangeMovement;

    [Tooltip("Дистанция атаки")] 
    [Range(1, 15)] public float AttackDistance;

    [Tooltip("Время неподвижности")]
    [Range(1,5)] public float TimeImmobility;
    
    [Tooltip("Здоровье")]
    [Range(1,10)] public int Health;
    
    public NavMeshAgent Agent => _agent;
    
    public Weapon EnemyWeapon => _enemyWeapon;
}
