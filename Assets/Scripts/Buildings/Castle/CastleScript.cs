using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


public class CastleScript : MonoBehaviour
{
    public float MaxHP;
    public float HP;
    public GameObject GameOverMassage;
    public GameUIManager UIManager;
    public Image HpBar;
    public GameObject PlayingUIElements;
    public GameObject CastleDamageParticleEffect;
    public Transform CastlePosition;
    public float CastleWidth = 5;
    bool AlreadyGameOver = false;
    public AudioSource AudioSource;
    bool CanPlay = true;
    GlobalEnemiesManager Manager;
    public AdsManager adsManager;
    public ShopProductsScriptableObject Shop;

    void Start()
    {
        Manager = LinksContainer.instance.globalEnemiesManager;
        if (Shop.GetProductPurchaseState("StrongWalls") == true)
        {
            MaxHP = MaxHP * 1.5f;
            HP = HP * 1.5f;
        }
        PlayingUIElements = LinksContainer.instance.PlayingUIElements;
        HpBar = LinksContainer.instance.HpBar;
        UIManager = LinksContainer.instance.UIManager;
        HP = MaxHP;
    }
    // Update is called once per frame
    void Update()
    {
        Manager.CastlePosition = gameObject.transform.position;
        HpBar.fillAmount = HP / MaxHP;
        if (HP <= 0 && AlreadyGameOver == false)
        {
            GameOver();
            AlreadyGameOver = true;
        }

    }
    void GameOver ()
    {
        PlayingUIElements.SetActive(false);
        UIManager.ShowGameOverScreen();
        StartCoroutine("StopTime");

    }
    public void Restart ()
    {
        SceneManager.LoadScene(1);
    }
    public void DamageReceive(float Damage, Vector3 EnemyPosition)
    {
        HP -= Damage;
        ShowParticleEffect(EnemyPosition, Damage);
    }
    public void ShowParticleEffect (Vector3 EnemyPosition, float Damage)
    {
        Vector3 Normilized = (EnemyPosition - CastlePosition.position).normalized;
        Vector3 EffectPosition = (Normilized * CastleWidth / 2) + CastlePosition.position;
        var NewParticle = Instantiate(CastleDamageParticleEffect, EffectPosition, Quaternion.identity);
        float Scale = 0.12f * Damage;
        Scale = Mathf.Clamp(Scale, 0.06f, 0.22f);
        NewParticle.transform.localScale = new Vector3(Scale, Scale, Scale);
        Destroy(NewParticle, 2);
    }
    public void HitSound(AudioClip[] HitSounds)
    {
        if (AudioSource.isPlaying == false && CanPlay == true)
        {
            AudioSource.clip = HitSounds[Random.Range(1, HitSounds.Length)];
            AudioSource.Play();
            CanPlay = false;
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        CanPlay = true;
    }
    IEnumerator StopTime()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;
    }

}
