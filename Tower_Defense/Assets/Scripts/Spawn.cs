using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawn : MonoBehaviour
{
    [HideInInspector]
    public bool IsLock = true;

    [HideInInspector]
    public bool CouldWork;

    public GameObject ToolForEnemyInfo;

    public GameObject ToolForTowerInfo;

    public GameObject ToolForUnitsCount;

    public GameObject UnitsAtMapCounter;

    public int WaveSize;

    public Text currentGold;

    public float WavesDelay;

    public GameObject[] Enemy;

    private int currentWave;

    public float Interval;

    public float StartTime;

    public Transform SpawnPoint;

    public Transform[] waypoints;

    int CurrentCnt = 0;

    bool Spawning;

    void Start()
    {
        Spawning = false;
        currentWave = 0;
        UnitsAtMapCounter.GetComponent<StageAndUnitsAtMapCounter>().EnemyNextWave = Enemy[0];
        UnitsAtMapCounter.GetComponent<StageAndUnitsAtMapCounter>().IsLock = false;
    }

    void Update()
    {
        if (CouldWork)
        {
            if (!IsLock && !Spawning)
            {
                InvokeRepeating("SpawnEnemy", StartTime, Interval);
                Spawning = true;
            }

            if (CurrentCnt == WaveSize && currentWave == Enemy.Length - 1)
            {
                enabled = false;
            }

            if (CurrentCnt == WaveSize)
            {
                CurrentCnt = 0;
                currentWave++;
                IsLock = true;

                UnitsAtMapCounter.GetComponent<StageAndUnitsAtMapCounter>().EnemyNextWave = Enemy[currentWave];
                UnitsAtMapCounter.GetComponent<StageAndUnitsAtMapCounter>().IsLock = false;

                if (currentWave == Enemy.Length - 1)
                    UnitsAtMapCounter.GetComponent<StageAndUnitsAtMapCounter>().LastWave = true;

                enabled = false;
                CancelInvoke("SpawnEnemy");
                StartCoroutine(wait());
            }
        }
    }

    void SpawnEnemy()
    {
        ToolForUnitsCount.GetComponent<UnitCounterScript>().Increment();

        GameObject enemy = Instantiate(Enemy[currentWave], SpawnPoint.position, Quaternion.identity) as GameObject;
        CurrentCnt++;

        enemy.GetComponent<MoveToWayPoints>().waypoints = waypoints;
        enemy.GetComponent<Enemy>().currentGold = currentGold;
        enemy.GetComponent<Enemy>().ToolForEnemyInfo = ToolForEnemyInfo;
        enemy.GetComponent<Enemy>().ToolForTowerInfo = ToolForTowerInfo;
        enemy.GetComponent<Enemy>().ToolForUnitsCount = ToolForUnitsCount;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(WavesDelay);
        Spawning = false;
        InvokeRepeating("SpawnEnemy", StartTime, Interval);
        enabled = true;
    }
}
