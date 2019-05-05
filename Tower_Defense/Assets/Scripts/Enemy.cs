using System;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour {

    [HideInInspector]
    public float currentHP;

    [HideInInspector]
    public Text currentGold;

    [HideInInspector]
    public GameObject ToolForEnemyInfo;

    [HideInInspector]
    public GameObject ToolForTowerInfo;

    [HideInInspector]
    public bool isAlive;

    [HideInInspector]
    public GameObject ToolForUnitsCount;

    public string Name;

    private Animation anim;

    public bool IsDeathAnim;

    public GameObject MouseEnter;

    public int Income;

    public Image HP_bar;

    public float startHP;

    public string TypeOfArmor;

    public float Armor;

    public float Speed;

	// Use this for initialization
	void Start ()
    {
        currentHP = startHP;
        anim = transform.GetComponent<Animation>();
        isAlive = true;
        transform.GetComponent<MoveToWayPoints>().Speed = Speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (currentHP > 0)
            HP_bar.fillAmount = currentHP / startHP;
        else
            HP_bar.fillAmount = 0;

        anim.Play("Run");
        if (!isAlive)
            Death();
    }

    public void OnMouseDown()
    {
        ToolForEnemyInfo.GetComponent<RenderInfoEnemy>().Enemy = transform.gameObject;
        ToolForTowerInfo.GetComponent<RenderInfoTower>().Tower = null;
    }

    private void OnMouseEnter()
    {
        MouseEnter.SetActive(true);
    }

    private void OnMouseExit()
    {
        MouseEnter.SetActive(false);
    }

    private void Death()
    {
        ToolForUnitsCount.GetComponent<UnitCounterScript>().Decrement();
        int gold = Convert.ToInt32(currentGold.text.Split(' ')[2]);
        gold += Income;
        currentGold.text = "Current gold: " + Convert.ToString(gold);
        enabled = false;
        transform.GetComponent<MoveToWayPoints>().enabled = false;
        if (IsDeathAnim)
            anim.Play("Death2");
        else
            anim.Stop("Run");
        Destroy(transform.gameObject, 2);
    }
}
