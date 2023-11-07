using UnityEngine;
using UnityEngine.AI;

public sealed class EnemyView : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    [Header("Характеристики AI")]
    
    [Tooltip("Скорость")]
    [Range(1,10)] public int Speed;
    
    [Tooltip("Дальность передвижения")]
    [Range(1,20)] public float RangeMovement;
    
    [Tooltip("Время неподвижности")]
    [Range(1,5)] public float TimeImmobility;
    
    [Tooltip("Здоровье")]
    [Range(1,10)] public int Health;
    
    [Tooltip("Скорость перезарядки")]
    [Range(0.1F,2)] public float CoolDown;
    
    [Tooltip("Урон")]
    [Range(1,5)] public int Damage;
    
    public NavMeshAgent Agent => _agent;
}
