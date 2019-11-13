using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralScript : MonoBehaviour
{
    public float DamageIncrease;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy") {
            if (gameObject.transform.parent.GetComponent<EnemyBehaviour>().AlreadyDead == false)
            {
                Col.gameObject.GetComponent<EnemyBehaviour>().SetGeneralInspiration(DamageIncrease);
            }
            else
            {
                Col.gameObject.GetComponent<EnemyBehaviour>().DeliteGeneralInspiration(DamageIncrease);
            }
        }
    }
    void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "Enemy")
        {
            Col.gameObject.GetComponent<EnemyBehaviour>().DeliteGeneralInspiration(DamageIncrease);
        }
    }
}

