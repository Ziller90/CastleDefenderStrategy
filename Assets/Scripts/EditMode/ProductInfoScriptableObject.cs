using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProduct", menuName = "Product")]
public class ProductInfoScriptableObject : ScriptableObject
{
    public Translation ImprovementName;
    public Translation ImprovementDescription;
    public Sprite ImprovementImage;
    public string ID;
    public int Price;


    void Start()
    {
        
    }


    void Update()
    {
                     
    }
}
