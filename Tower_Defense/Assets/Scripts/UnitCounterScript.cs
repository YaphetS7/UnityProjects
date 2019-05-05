using System;
using UnityEngine;
using UnityEngine.UI;
public class UnitCounterScript : MonoBehaviour
{
    public GameObject StageCounter;

    public Text CntOfUnits;

    public void Increment()
    {
        int NewCount = GetCount(CntOfUnits.text) + 1;
        CntOfUnits.text = "Units: " + NewCount;
    }

    public void Decrement()
    {
        int NewCount = GetCount(CntOfUnits.text) - 1;
        CntOfUnits.text = "Units: " + NewCount;
    }

    private int GetCount(string s)
    {
        return Convert.ToInt32(s.Split(' ')[1]);
    }

    private void Update()
    {
        if(GetCount(CntOfUnits.text) == 0 && StageCounter.GetComponent<StageAndUnitsAtMapCounter>().LastWave)
        {
            StageCounter.GetComponent<StageAndUnitsAtMapCounter>().IsVictory = true;
        }
    }
}
