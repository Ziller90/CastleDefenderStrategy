using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesScript : MonoBehaviour
{
    public float Damage;
    public bool Reloaded;
    void OnTriggerStay (Collider col)
    {
        if (col.gameObject.tag == "Enemy" && Reloaded == true)
        {
            StartCoroutine("Attack", col.gameObject);
            Reloaded = false;
        }
    }
    public IEnumerator Attack (GameObject ObjectToAttack)
    {
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Attack", true);
        yield return new WaitForSeconds(0.4f);
        if (ObjectToAttack != null)
        {
            ObjectToAttack.gameObject.GetComponent<EnemyBehaviour>().HP = ObjectToAttack.gameObject.GetComponent<EnemyBehaviour>().HP - Damage;
        }
        gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Attack", false);
        yield return new WaitForSeconds(1f);
        Reloaded = true;
    }
}
