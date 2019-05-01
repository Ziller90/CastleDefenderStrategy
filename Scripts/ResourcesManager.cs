using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    public  int Gold = 1000;
    public Text GoldText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GoldText.text = "" + Gold;
    }
}
