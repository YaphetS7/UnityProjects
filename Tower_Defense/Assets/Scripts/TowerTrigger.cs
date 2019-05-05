using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    public Tower tower;

    [HideInInspector]
    public bool haveEnemy;

    [HideInInspector]
    public GameObject curTarget;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !haveEnemy && other.gameObject.GetComponent<Enemy>().isAlive)
        {
            tower.target = other.gameObject.transform;
            curTarget = other.gameObject;
            haveEnemy = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }

    void Update()
    {

        if (curTarget != null && !curTarget.gameObject.GetComponent<Enemy>().isAlive)
        {
            curTarget = null;
            tower.target = null;
            haveEnemy = false;
        }

    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy") && other.gameObject == curTarget)
        {
            tower.currentDamage = tower.damage;
            haveEnemy = false;
            curTarget = null;
            tower.target = null;
        }
    }
}
