using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineInfoPanel : MonoBehaviour
{
    public Transform MainCamera;
    public GameObject InfoCanvas;
    public Transform GoldIndicator;
    void Start()
    {
        MainCamera = GameObject.Find("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        GoldIndicator.transform.localScale = new Vector3((gameObject.GetComponent<MineScript>().GoldLeft / gameObject.GetComponent<MineScript>().MineResource), 1, 1);
      
    }
    public void ShowPanel ()
    {
        InfoCanvas.SetActive(true);
    }
    public void HidePanel ()
    {
        InfoCanvas.SetActive(false);
    }
    
} 
