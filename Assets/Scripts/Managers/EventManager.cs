using System;

public class EventManager
{
    public static Action onEnemyDeath;

    public void EnemyDeath()
    {
        if(onEnemyDeath != null) {onEnemyDeath.Invoke();}
    }
}
