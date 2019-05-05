using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
public class StageAndUnitsAtMapCounter : MonoBehaviour
{
    [HideInInspector]
    public bool LastWave;

    [HideInInspector]
    public GameObject EnemyNextWave;

    [HideInInspector]
    public bool IsLock;

    [HideInInspector]
    public bool IsVictory = false;

    [HideInInspector]
    public bool CouldWork;

    public GameObject SpawnPoint;

    public Text VictoryText;

    public Text NameOfEnemy;

    public Text SpeedOfEnemy;

    public Text TypeOfArmorEnemy;

    public Text ArmorOfEnemy;

    public Text HpOfEnemy;

    bool IsShowed;

    private void Start()
    {
        IsLock = true;
    }

    void Update()
    {
        if (CouldWork)
        {
            if (!IsLock)
            {
                StartCoroutine(ShowInfo());
                IsLock = true;
            }


            if (IsVictory)
            {
                VictoryText.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    IEnumerator ShowInfo()
    {
        IsShowed = true;
        TurnTexts();

        if (!LastWave)
            NameOfEnemy.text = "Next wave is " + EnemyNextWave.GetComponent<Enemy>().name;
        else
            NameOfEnemy.text = "LAST WAVE IS " + EnemyNextWave.GetComponent<Enemy>().name;

        SpeedOfEnemy.text = "Speed: " + Convert.ToString(EnemyNextWave.GetComponent<Enemy>().Speed);

        TypeOfArmorEnemy.text = "Type of armor: " + EnemyNextWave.GetComponent<Enemy>().TypeOfArmor;

        ArmorOfEnemy.text = "Armor: " + Convert.ToString(EnemyNextWave.GetComponent<Enemy>().Armor);

        HpOfEnemy.text = "HP: " + Convert.ToString(EnemyNextWave.GetComponent<Enemy>().startHP);

        yield return new WaitForSeconds(7);

        IsShowed = false;
        SpawnPoint.GetComponent<Spawn>().IsLock = false;
        TurnTexts();
    }

    void TurnTexts()
    {
        NameOfEnemy.gameObject.SetActive(IsShowed);
        SpeedOfEnemy.gameObject.SetActive(IsShowed);
        TypeOfArmorEnemy.gameObject.SetActive(IsShowed);
        ArmorOfEnemy.gameObject.SetActive(IsShowed);
        HpOfEnemy.gameObject.SetActive(IsShowed);
    }
}
