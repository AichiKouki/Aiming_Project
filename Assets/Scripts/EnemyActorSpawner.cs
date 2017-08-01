using UnityEngine;

public class EnemyActorSpawner : Spawner
{

    private void Start()
    {
        var go = Spawn();
        go.AddComponent<ThirdPersonEnemyController>();
        go.tag = "Enemy";
     }
}