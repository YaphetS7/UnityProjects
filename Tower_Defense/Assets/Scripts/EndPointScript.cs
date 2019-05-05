using System;
using UnityEngine;
using UnityEngine.UI;
public class EndPointScript : MonoBehaviour
{

    public Text LifesINfo;

    public Text GameOverText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().isAlive = false;
            int currentLifes = GetLifes(LifesINfo.text) - 1;
            LifesINfo.text = "Lifes: " + currentLifes;
            if (currentLifes <= 0)
            {
                Time.timeScale = 0;
                GameOverText.gameObject.SetActive(true);
            }
        }
    }

    private int GetLifes(string s)
    {
        return Convert.ToInt32(s.Split(' ')[1]);
    }
}
