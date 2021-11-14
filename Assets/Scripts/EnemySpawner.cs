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

    void Start()
    {
        if (!isEnemy && !spawned)
        {
            Spawn();
            spawned = true;
        }
    }

    private void Update()
    {

    }

    public void Spawn()
    {
        GameObject obj = Instantiate(Prefab, spawnPos, Quaternion.identity);
        obj.GetComponent<Animator>().SetTrigger("isBorn");
        EnemyDamage ed = obj.GetComponent<EnemyDamage>();
        ed.hitPoints = ed.maxHitPoints;
        obj.GetComponent<RobotController>().isAttacked = false;
        obj.GetComponent<Transform>().localScale = spawnScale;
    }
}
