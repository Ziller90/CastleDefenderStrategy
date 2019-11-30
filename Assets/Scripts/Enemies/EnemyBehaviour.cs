using System.Collections;
using UnityEngine;

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
    public GameObject Castle;
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
    public GameObject PoisonEffect;
    public GlobalEnemiesManager globalEnemiesManager;
    public float AttackRange;
    public int WayIndex;








    void Start()
    {
        Enemy.transform.SetParent(null);
        globalEnemiesManager = GameObject.Find("GlobalEnemiesManager").GetComponent<GlobalEnemiesManager>();
        globalEnemiesManager.RegisterEnemy(gameObject);
        EnemyAnimator.SetFloat("Speed", NormalAnimationsSpeed);
        CameraViewPoint = GameObject.Find("CameraViewPoint");
        HP = MaxHP;
        HPIndex = 1;
        Go = true;
        Castle = GameObject.FindGameObjectWithTag("Castle");
    }

    void Update ()
    {
        if (globalEnemiesManager.CanEnemyAttackCastle(Enemy.transform.position, AttackRange))
        {
            if (EnemyId == "Infanity")
                StartCoroutine("AttackCastle");
            if (EnemyId == "General")
                StartCoroutine("AttackCastle");
            if (EnemyId == "Archer")
                StartCoroutine("AttackDelay");
            if (EnemyId == "Catapult")
                StartCoroutine("AttackDelay");
        }
    }
    void FixedUpdate()
    {
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
            Enemy.transform.position += transform.forward * speed;
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
            float Delay = Random.Range(0.1f, 0.7f);
            yield return new WaitForSeconds(Delay);
            Go = false;
            EnemyAnimator.SetBool("Attack", true);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine("AttackCastle");
        }
    }
    public void OnAttack ()
    {
        Castle.GetComponent<CastleScript>().DamageReceive(EnemyDamage, gameObject.transform.position);
    }
    public IEnumerator Death ()
    {
        globalEnemiesManager.UnRegisterEnemy(gameObject);
        gameObject.GetComponent<EffectsResistance>().DieEffects();
        EnemyAnimator.SetBool("Dead", true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameObject Resourcesmanager = GameObject.Find("ResourcesManager");
        Resourcesmanager.GetComponent<ResourcesManager>().Gold = Resourcesmanager.GetComponent<ResourcesManager>().Gold + KillReward;
        AddCrystals();
        Go = false;
        HPBar.gameObject.SetActive(false);
        DeathSoundPlaying();
        yield return new WaitForSeconds(4);
        Destroy(Enemy);
    }
    public void AddCrystals ()
    {
        int rand = Random.Range(1, 101);
        if (rand <= ProbabilytyOfCrystalsReward)
        {
            PlayerStats.Crystals += CrystalsKillReward;
        }
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
}
