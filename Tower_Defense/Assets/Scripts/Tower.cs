using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [HideInInspector]
    public Transform target;

    [HideInInspector]
    public GameObject ToolForEnemyInfo;

    [HideInInspector]
    public GameObject ToolForTowerInfo;

    [HideInInspector]
    public float currentDamage;

    [Header("For Frost Tower")]
    public bool IsFrostTower;

    public float SlowDown;

    public Animation anim;

    [Header("For Laser Tower")]
    public bool isLaserTower;

    public Transform PartToRotate;

    public LineRenderer lineRenderer;

    [Header("For all towers")]
    public float damage;

    public GameObject Bullet;

    public string TypeOfDamage;

    public GameObject MouseEnter;

    public float shootDelay;

    public Transform shootElement;

	void Start ()
    {
        currentDamage = damage;
	}
	
	void Update ()
    {
        if (target != null)
        {
            if (!isLaserTower)
                StartCoroutine(shoot());
            else
            {
                Laser();
                LockOnTarget();
            }
        }
        else
            if (isLaserTower)
            {
                  currentDamage = damage;
                  lineRenderer.enabled = false;
            }
        if (IsFrostTower)
            anim.Play("Idle");
	}

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookrotation, Time.deltaTime * 8).eulerAngles;
        PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void OnMouseDown()
    {
        ToolForEnemyInfo.GetComponent<RenderInfoEnemy>().Enemy = null;
        ToolForTowerInfo.GetComponent<RenderInfoTower>().Tower = transform.gameObject;
    }

    private void OnMouseEnter()
    {
        MouseEnter.SetActive(true);
    }

    private void OnMouseExit()
    {
        MouseEnter.SetActive(false);
    }

    private void Laser()
    {
        DoDamageFromLaser();
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, shootElement.position);
        lineRenderer.SetPosition(1, target.position + new Vector3(0f, 1f, 0f));
    }

    private void DoDamageFromLaser()
    {
        target.gameObject.GetComponent<Enemy>().currentHP -= currentDamage;
        currentDamage += damage;
        if (target.gameObject.GetComponent<Enemy>().currentHP <= 0f)
            target.gameObject.GetComponent<Enemy>().isAlive = false;
    }

    IEnumerator shoot()
    {
        enabled = false;
        GameObject bullet = GameObject.Instantiate(Bullet, shootElement.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().damage = damage;
        bullet.GetComponent<BulletScript>().target = target;
        yield return new WaitForSeconds(shootDelay);
        enabled = true;
    }
}
