using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public GameObject Spawner;

    public GameObject InfoRenderer;

    public Camera Camera1;

    public Camera Camera2;

    private void OnMouseDown()
    {
        Spawner.GetComponent<Spawn>().CouldWork = true;
        InfoRenderer.GetComponent<StageAndUnitsAtMapCounter>().CouldWork = true;

        Camera1.gameObject.SetActive(false);
        Camera2.gameObject.SetActive(true);
    }

}
