using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay (Collider Col)
    {
        if (Col.gameObject.tag == "Castle" || Col.gameObject.tag == "StopTower")
        {
            gameObject.transform.parent.GetComponent<EnemyBehaviour>().SeeTheEnemy = true;
        }
    }
}
