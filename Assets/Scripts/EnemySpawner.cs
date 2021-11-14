using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
   
    public GameObject Prefab;

    //public float SpawnInterval = 2;
    //public float InitSpawnInterval = 3;
    //public float Count = 0;
    public Vector3 spawnPos = new Vector3(0, 0, 1);
    public Vector3 spawnScale = new Vector3(2, 2, 1);

    private bool spawned = false;

    public bool isEnemy = false;

    public void Spawn()
    {
        int side = 1; 
        if (Random.Range(0.0f, 1.0f) >= 0.5)
        {
            side = -1;
        }

        spawnPos = new Vector3(side * Random.Range(9.0f, 8.0f), -4, 1);

        GameObject obj = Instantiate(Prefab, spawnPos, Quaternion.identity);
        obj.GetComponent<Animator>().SetTrigger("isBorn");
        EnemyMovement ea = obj.GetComponent<EnemyMovement>();
        ea.speed = ea.initSpeed;
        EnemyDamage ed = obj.GetComponent<EnemyDamage>();
        ed.hitPoints = ed.maxHitPoints;
        RobotController rc = obj.GetComponent<RobotController>();
        if (side == 1)
        {
            rc.isFacingRight = false;
            ea.xDisplacement = -1 * ea.initXDisplacement;
            spawnScale.x = -2;
        } else
        {
            rc.isFacingRight = true;
            ea.xDisplacement = ea.initXDisplacement;
            spawnScale.x = 2;
        }
           
        rc.isAttacked = false;
        rc.isAttacking = false;
        obj.GetComponent<Transform>().localScale = spawnScale;
        
    }
}
