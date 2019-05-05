using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed;

    [HideInInspector]
    public float damage;

    [HideInInspector]
    public Transform target;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            Destroy(transform.gameObject);
            target.gameObject.GetComponent<Enemy>().currentHP -= damage;

            if (target.gameObject.GetComponent<Enemy>().currentHP <= 0f)
                target.gameObject.GetComponent<Enemy>().isAlive = false;
            
            enabled = false;
        }
	}

  
}
