using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcOnInVisibleDisabling : MonoBehaviour
{
    public GameObject Orc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnBecameInvisible()
    {
        Orc.SetActive(false);
    }
    void OnBecameVisible()
    {
        Orc.SetActive(true);
    }
}
