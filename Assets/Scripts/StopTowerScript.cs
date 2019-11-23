using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTowerScript : MonoBehaviour
{
    public float HP;
     

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine("Deleting");
        }
    }
    IEnumerator Deleting ()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
