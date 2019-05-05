using System;
using UnityEngine;
using UnityEngine.UI;
public class RenderInfoEnemy : MonoBehaviour
{
    [HideInInspector]
    public GameObject Enemy;

    public Button tower1;

    public Button tower2;

    public Button tower3;

    public Text HP;

    public Text Speed;

    public Text TypeOfArmor;

    public Text Armor;

	void Update ()
    {
		if(Enemy != null && Enemy.GetComponent<Enemy>().isAlive)
        {
            tower1.gameObject.SetActive(false);
            tower2.gameObject.SetActive(false);
            tower3.gameObject.SetActive(false);

            HP.gameObject.SetActive(true);
            Speed.gameObject.SetActive(true);
            TypeOfArmor.gameObject.SetActive(true);
            Armor.gameObject.SetActive(true);

            Speed.text = "Speed: " + Convert.ToString(Enemy.GetComponent<Enemy>().Speed);

            HP.text = "HP: "
                + Convert.ToString(Math.Ceiling(Enemy.GetComponent<Enemy>().currentHP))
                + " / " + Convert.ToString(Enemy.GetComponent<Enemy>().startHP);

            TypeOfArmor.text = "Type of armor: " + Enemy.GetComponent<Enemy>().TypeOfArmor;

            Armor.text = "Armor: " + Convert.ToString(Enemy.GetComponent<Enemy>().Armor);
        }
        else
        {
            HP.gameObject.SetActive(false);
            Speed.gameObject.SetActive(false);
            TypeOfArmor.gameObject.SetActive(false);
            Armor.gameObject.SetActive(false);
        }
	}
}
