using System;
using UnityEngine;
using UnityEngine.UI;
public class AddTower : MonoBehaviour
{
    public GameObject ToolForEnemyInfo;

    public GameObject ToolForTowerInfo;

    public Text gold;

    public int Price;

    public Vector3 offset;

    public GameObject Tower;

    [HideInInspector]
    public GameObject Place;

    public void CreateTower()
    {
        int currentGold = GetGold(gold.text);
        if (currentGold >= Price)
        {
            GameObject tower = Instantiate(Tower, Place.transform.position + offset, Quaternion.identity);
            Place.GetComponent<TowerPlace>().empty = false;
            Place.GetComponent<TowerPlace>().OffButtons();
            tower.GetComponent<Tower>().ToolForEnemyInfo = ToolForEnemyInfo;
            tower.GetComponent<Tower>().ToolForTowerInfo = ToolForTowerInfo;
            currentGold -= Price;
            gold.text = "Current gold: " + Convert.ToString(currentGold);
        }
    }
	
	private int GetGold(string s)
    {
        return Convert.ToInt32(s.Split(' ')[2]);
    }
}
