using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaEnemyDetector : MonoBehaviour
{
    public Transform Lamp;
    public float Damage;
    public bool Frozen;
    bool AlreadyFinded = false;
    GlobalEnemiesManager globalEnemiesManager;
    public float RangeOfDetection;
     
    void Start()
    {
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
        if (ShopManager.SuperMine == true)
        {
            Debug.Log("Mine");
            RangeOfDetection = RangeOfDetection * 1.5f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Frozen == false)
        gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.red, Color.white, Mathf.PingPong(Time.time, 0.3f));
        else
        gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(Color.blue, Color.white, Mathf.PingPong(Time.time, 0.3f));

        if (globalEnemiesManager.IsEnemyInRadius(gameObject.transform.position, RangeOfDetection) && AlreadyFinded == false)
        {
            StartCoroutine("MinaDelay");
            AlreadyFinded = true;
        }
    }
    IEnumerator MinaDelay()
    {
        yield return new WaitForSeconds(0.1f);
        Lamp.localPosition = new Vector3(Lamp.localPosition.x, 0.211f, Lamp.localPosition.z);
        yield return new WaitForSeconds(1.5f);
        if (ShopManager.SuperMine == true)
        {
            yield return new WaitForSeconds(0.5f);
        }
        gameObject.transform.parent.GetComponent<MineExplosion>().Explose(Damage);
    }
}
