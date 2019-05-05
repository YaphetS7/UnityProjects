using System;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlace : MonoBehaviour
{
    public GameObject ToolForRenderEnemyInfo;

    public GameObject ToolForRenderTowerInfo;

    public Button Default;

    public Button Laser;

    public Button Frost;

    [HideInInspector]
    public bool empty = true;

    private void OnMouseDown()
    {
        ToolForRenderEnemyInfo.GetComponent<RenderInfoEnemy>().Enemy = null;
        ToolForRenderTowerInfo.GetComponent<RenderInfoTower>().Tower = null;

        if (empty)
        {
            Default.gameObject.SetActive(true);
            Laser.gameObject.SetActive(true);
            Frost.gameObject.SetActive(true);

            Default.GetComponent<AddTower>().Place = transform.gameObject;
            Laser.GetComponent<AddTower>().Place = transform.gameObject;
            Frost.GetComponent<AddTower>().Place = transform.gameObject;
        }
    }

    public void OffButtons()
    {
        Default.gameObject.SetActive(false);
        Laser.gameObject.SetActive(false);
        Frost.gameObject.SetActive(false);
    }
}
