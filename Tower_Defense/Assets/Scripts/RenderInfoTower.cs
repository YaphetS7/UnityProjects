using System;
using UnityEngine.UI;
using UnityEngine;

public class RenderInfoTower : MonoBehaviour
{
    [HideInInspector]
    public GameObject Tower;

    public Button tower1;

    public Button tower2;

    public Button tower3;

    public Text AttackSpeed;

    public Text TypeOfDamage;

    public Text Damage;

    void Update ()
    {
        if (Tower != null)
        {
            tower1.gameObject.SetActive(false);
            tower2.gameObject.SetActive(false);
            tower3.gameObject.SetActive(false);

            AttackSpeed.gameObject.SetActive(true);
            TypeOfDamage.gameObject.SetActive(true);
            Damage.gameObject.SetActive(true);

            string temp = Convert.ToString(1 / Tower.GetComponent<Tower>().shootDelay);

            AttackSpeed.text = "Attack Speed: "
                + temp
                + " per second";

            Damage.text = "Damage: " + Convert.ToString(Tower.GetComponent<Tower>().currentDamage);

            TypeOfDamage.text = "Type of damage: " + Tower.GetComponent<Tower>().TypeOfDamage;
        }
        else
        {
            AttackSpeed.gameObject.SetActive(false);
            TypeOfDamage.gameObject.SetActive(false);
            Damage.gameObject.SetActive(false);
        }
    }
}
