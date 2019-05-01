using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CastleScript : MonoBehaviour
{
    public float HP;
    public GameObject GameOverMassage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            GameOver();
        }
    }
    void GameOver ()
    {
        GameOverMassage.SetActive(true);
    }
    void Win ()
    {

    }
    public void Restart ()
    {
        SceneManager.LoadScene(1);
    }

}
