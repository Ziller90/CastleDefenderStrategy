using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehaviour : MonoBehaviour
{
    public int RouteNumber;
    public float NormalSpeed;
    public float speed;
    public float MaxHP;
    public float HP;
    public Transform HPLine;
    public float NewHPIndex;
    public float HPIndex;
    public float ChangingSpeed;
    public GameObject CameraViewPoint;
    public Transform HPBar;
    public Transform HPBarPoint;
    public GameObject Enemy;
    public CastleScript Castle;
    public bool Go;
    public float EnemyDamage;
    public string EnemyId;
    public int KillReward;
    public int CrystalsKillReward;
    public int FrozenRecover;
    public Animator EnemyAnimator;

    public bool AlreadyDead = false;
    public int ProbabilytyOfCrystalsReward;
    public AudioSource Audio;
    public float NormalAnimationsSpeed;
    public bool WasInspirated;
    public AudioClip[] DeathAudioClips;
    public ParticleSystem HealingParticle;
    public bool Poisoned;
    public bool Burning;
    public GameObject PoisonEffect;
    public GlobalEnemiesManager globalEnemiesManager;
    public float AttackRange;
    public int WayIndex;
    public Transform[] WayPoints;
    Transform EnemyTransform;
    WinScript winScript;
    public bool AlreadyAttack;
    public int AnimationIndex;
    public bool FullFreezed;
    public GameObject IceCube;
    public float MinStopTime;
    public float MaxStopTime;
    public Material StandartMaterial;
    public Material DarkVersionMaterial;
    public SkinnedMeshRenderer Renderer;







    void Awake()
    {
        if (Renderer != null)
        {
            if (LinksContainer.instance.Level.GetComponent<MapSetting>().LevelNumber >= 10)
            {
                Renderer.material = DarkVersionMaterial;
            }
        }
    }
    public void Attack()
    {
      if (AlreadyAttack == false)
        {
            if (EnemyId == "Infanity" || EnemyId == "General" || EnemyId == "Cavalry" || EnemyId == "Healer")
                StartCoroutine("AttackCastle");
            if (EnemyId == "Archer")
                gameObject.GetComponent<ArcherDistanceAttack>().StartCoroutine("AttackDelay");
            if (EnemyId == "Catapult")
                gameObject.GetComponent<CatapultDistanceAttack>().StartCoroutine("AttackDelay");
            AlreadyAttack = true;
        }
    }
    void Start()
    {
        if (SceneManager.GetSceneByBuildIndex(5).isLoaded == false)
        {
            switch (PlayerStats.DifficultyLevelIndex)
            {
                case 0:
                    MaxHP = MaxHP * 0.85f;
                    break;
                case 1:
                    MaxHP = MaxHP * 0.6f;
                    break;
                case 2:
                    MaxHP = MaxHP * 0.85f;                
                    break;
                case 3:
                    MaxHP = MaxHP * 1.35f;
                    break;
            }
        }
        CameraViewPoint = LinksContainer.instance.CameraViewPoint;
        MinStopTime = MinStopTime * 0.1f;
        MaxStopTime = MaxStopTime * 0.1f;

        IceCube.SetActive(false);
        AnimationIndex = 1;
        winScript = LinksContainer.instance.winScript;
        winScript.Enemies.Add(gameObject);
        EnemyTransform = Enemy.transform;
        Enemy.transform.SetParent(null);
        globalEnemiesManager = LinksContainer.instance.globalEnemiesManager;
        globalEnemiesManager.RegisterEnemy(gameObject);
        HP = MaxHP;
        HPIndex = 1;
        Go = true;
        Castle = LinksContainer.instance.Castle;
    }

    void Update()
    {
        if (FullFreezed == true)
        {
           EnemyAnimator.speed = 0;
        }
        if (AlreadyDead == true)
        {
            Poisoned = false;
        }
        if (Poisoned == false)
        {
            PoisonEffect.SetActive(false);
        }
        if (Poisoned == true)
        {
            PoisonEffect.SetActive(true);
        }
        if (Go == true)
        {
            EnemyTransform.position = Vector3.MoveTowards(EnemyTransform.position, WayPoints[WayIndex].position, speed * 50 * Time.deltaTime);
            if (EnemyTransform.position == WayPoints[WayIndex].position)
            {
                WayIndex++;
                EnemyTransform.LookAt(WayPoints[WayIndex]);
            }
        }
        if (EnemyId != "Cavalry" && EnemyId != "Healer" && EnemyId != "Catapult" && FullFreezed == false)
        {
            switch (AnimationIndex)
            {
                case 1:
                    EnemyAnimator.Play("Run");
                    break;
                case 0:
                    EnemyAnimator.Play("Attack");
                    break;
                case 2:
                    EnemyAnimator.Play("Death");
                    break;
            }
        }
        HPBar.position = HPBarPoint.position;
        HPBar.LookAt(CameraViewPoint.transform);

        NewHPIndex = HP / MaxHP;
        HPIndex = Mathf.Lerp(HPIndex, NewHPIndex, Time.deltaTime * ChangingSpeed);
        HPLine.localScale = new Vector3(HPIndex, HPLine.localScale.y, HPLine.localScale.z);

        if (HP <= 0 && AlreadyDead == false)
        {
            StartCoroutine("Death");
            AlreadyDead = true;
        }

        if (speed != NormalSpeed)
        {
            StartCoroutine("SpeedRecover");
        }
        if (HP > MaxHP)
            HP = MaxHP;
    }

    public void Heal(float AddedHp)
    {
        if (HP < MaxHP)
        {
            HP = HP + AddedHp;
            HealingParticle.Play();
        }
    }
    public void TurnRight ()
    {
        gameObject.transform.Rotate(0, 90, 0);
    }
    public void TurnLeft()
    {
        gameObject.transform.Rotate(0, -90, 0);
    }

    public IEnumerator SpeedRecover ()
    {
        yield return new WaitForSeconds(FrozenRecover);
        speed = NormalSpeed;
    }

    public IEnumerator AttackCastle ()
    {
        if (AlreadyDead == false)
        {
            float Delay = Random.Range(MinStopTime, MaxStopTime);
            yield return new WaitForSeconds(Delay);
            Go = false;
            if (EnemyId == "Cavalry" || EnemyId == "Healer" || EnemyId == "Catapult")
                EnemyAnimator.SetBool("Attack", true);
            else
                AnimationIndex = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void OnAttack ()
    {
        Castle.GetComponent<CastleScript>().DamageReceive(EnemyDamage, gameObject.transform.position);
        Castle.GetComponent<CastleScript>().HitSound(gameObject.GetComponent<AttackSounds>().AttackSound);
    }
    public IEnumerator Death ()
    {
        StopCoroutine("AttackCastle");
        AlreadyDead = true;
        winScript.Enemies.Remove(gameObject);
        globalEnemiesManager.UnRegisterEnemy(gameObject);
        gameObject.GetComponent<EffectsResistance>().DieEffects();
        if (EnemyId == "Cavalry" || EnemyId == "Healer" || EnemyId == "Catapult")
            EnemyAnimator.SetBool("Dead", true);
        else
            Debug.Log("ItWorks");
            AnimationIndex = 2;
        LinksContainer.instance.resourcesManager.Gold = LinksContainer.instance.resourcesManager.Gold + KillReward;
        Go = false;
        HPBar.gameObject.SetActive(false);
        DeathSoundPlaying();
        gameObject.GetComponent<CrystalsManager>().IfCrystalsDrop();
        yield return new WaitForSeconds(2.5f);
        Enemy.SetActive(false);

    }
    public void DeathSoundPlaying ()
    {
        int rand = Random.Range(0, (DeathAudioClips.Length + DeathAudioClips.Length));
        if (rand >= DeathAudioClips.Length)
        {
            return;
        }
        else
        {
            Audio.clip = DeathAudioClips[rand];
            Audio.Play();
        }
    }
    public void SetGeneralInspiration(float DamageIncrease)
    {
        if (WasInspirated == false)
        {
            EnemyDamage = EnemyDamage * DamageIncrease;
            WasInspirated = true;
        }
    }
    public void DeliteGeneralInspiration(float DamageIncrease)
    {
        if (WasInspirated == true)
        {
            EnemyDamage = EnemyDamage / DamageIncrease;
            WasInspirated = false;
        }
    }
    public IEnumerator Poison (float Damage)
    {
        if (Poisoned == true)
        {
            HP = HP - Damage * 0.2f;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine("Poison", Damage);
        }
    }
    public IEnumerator Burn(float Damage)
    {
        if (Burning == true)
        {
            HP = HP - Damage * 0.2f;
            yield return new WaitForSeconds(0.2f);
            StartCoroutine("Burn", Damage);
        }
    }
    public void FullFreeezeEnable()
    {
        FullFreezed = true;
        Go = false;
        IceCube.SetActive(true);
    }
    public void FullFreeezeDisable()
    {
        IceCube.SetActive(false);
        FullFreezed = false;
        if (AlreadyAttack == true)
        {
            EnemyAnimator.speed = 1;
            if (EnemyId == "Infanity" || EnemyId == "General" || EnemyId == "Cavalry" || EnemyId == "Healer")
                StartCoroutine("AttackCastle");
            if (EnemyId == "Archer")
                gameObject.GetComponent<ArcherDistanceAttack>().Attack();
            if (EnemyId == "Catapult")
                gameObject.GetComponent<CatapultDistanceAttack>().Attack();
        }
        else
        {
            Go = true;
            EnemyAnimator.speed = 1;
        }
    }
}
