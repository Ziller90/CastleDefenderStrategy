using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfView : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter (Collider Col)
    {
        if (Col.gameObject.tag == "Castle")
        {
            if (gameObject.transform.parent.GetComponent<EnemyBehaviour>().EnemyId == "Infanity" ) 
                gameObject.transform.parent.GetComponent<EnemyBehaviour>().StartCoroutine("AttackCastle");
            if (gameObject.transform.parent.GetComponent<EnemyBehaviour>().EnemyId == "General")
                gameObject.transform.parent.GetComponent<EnemyBehaviour>().StartCoroutine("AttackCastle");
            if (gameObject.transform.parent.GetComponent<EnemyBehaviour>().EnemyId == "Archer")
                gameObject.transform.parent.GetComponent<ArcherDistanceAttack>().StartCoroutine("AttackDelay");
            if (gameObject.transform.parent.GetComponent<EnemyBehaviour>().EnemyId == "Catapult")
                gameObject.transform.parent.GetComponent<CatapultDistanceAttack>().StartCoroutine("AttackDelay");
        }
    }
}
