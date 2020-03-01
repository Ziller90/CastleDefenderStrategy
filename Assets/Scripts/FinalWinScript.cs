using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalWinScript : MonoBehaviour
{
    public GameObject StartParticles;
    public ParticleSystem[] StartFireWorks;
    public ParticleSystem[] particleSystems;
    public Transform Camera;
    public Vector3 CameraPosition;
    public float speedForCamera;
    public GameObject FinalWinPanel;
    public GameObject FinalWinPanelNextButton;
    public GameObject UIElements;
    public AudioSource WinMusic;

    bool MoveCamera;
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("TouchCameraContr").transform;
        UIElements = GameObject.Find("PlayingUIElements");
    }

    void Update()
    {
        if (MoveCamera == true)
        {
            Camera.position = Vector3.MoveTowards(Camera.position, CameraPosition, speedForCamera * 25 * Time.deltaTime);
            Camera.GetChild(0).GetComponent<TouchCamera>().isFreezed = true;
        }
    }
    IEnumerator SalutStarts() 
    {
        MusicManager musicManager = LinksContainer.instance.musicManager;
        musicManager.StartCoroutine("StopMusic", 4f);
        for (int i = 0; i < StartFireWorks.Length; i++)
        {
            StartFireWorks[i].Play();
        }
        for (int i = 0; i < particleSystems.Length; i++)
        {
            yield return new WaitForSeconds(0.3f);
            particleSystems[i].Play();
        }
        MoveCamera = true;
        UIElements.SetActive(false);
        yield return new WaitForSeconds(1f);
        WinMusic.Play();
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        Destroy(StartParticles);
        FinalWinPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        FinalWinPanelNextButton.SetActive(true);
    }
    public void ToMainMenu()
    {
        PlayerStats.GameWasFinished = true;
        SceneManager.LoadScene(1);
    }

}
