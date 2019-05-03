using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int RouteNumber;
    public float NormalSpeed;
    public float speed;
    public float RotateTimes;
    public float RotatePover;
    public float MaxHP;
    public float HP;
    public float Delay;
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
 
   
    
    

    void Start()
    {
        CameraViewPoint = GameObject.Find("CameraViewPoint");
        HP = MaxHP;
        HPIndex = 1;
        Go = true;
        Castle = GameObject.Find("Castle");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Go == true)
        {
            gameObject.transform.position += transform.forward * speed;
        }
        HPBar.position = HPBarPoint.position;
        RotateTimes = 1;
        RotatePover = 90;
        Delay = 0.006f / speed;
        HPBar.LookAt(CameraViewPoint.transform);

        NewHPIndex = HP / MaxHP;
        HPIndex = Mathf.Lerp(HPIndex, NewHPIndex, Time.deltaTime * ChangingSpeed);
        HPLine.localScale = new Vector3(HPIndex, HPLine.localScale.y, HPLine.localScale.z);

        if (HP <= 0)
        {
            GameObject Resourcesmanager = GameObject.Find("ResourcesManager");
            Resourcesmanager.GetComponent<ResourcesManager>().Gold = Resourcesmanager.GetComponent<ResourcesManager>().Gold + KillReward;
            Destroy(Enemy);
        }

        if (speed != NormalSpeed)
        {
            StartCoroutine("SpeedRecover");
        }

    }
 
    public IEnumerator TurnRight ()
    {
        for (float t = 0; t < RotateTimes; t = t + 1)
        {
            yield return new WaitForSeconds(Delay);
            gameObject.transform.Rotate(0, RotatePover, 0);
        }
    }
    public IEnumerator TurnLeft()
    {
        for (float t = 0; t < RotateTimes; t = t + 1)
        {
            yield return new WaitForSeconds(Delay);
            gameObject.transform.Rotate(0, -RotatePover, 0);
        }
    }

    public IEnumerator SpeedRecover ()
    {
        yield return new WaitForSeconds(60);
        speed = NormalSpeed;
    }

    public void AttackModeStart (GameObject ObjectToAttack)
    {
        if (EnemyId == "Infanity")
        {
            gameObject.GetComponent<InfanityAttackBehavior>().StartCoroutine("Attack", ObjectToAttack);
            gameObject.GetComponent<InfanityAttackBehavior>().Damage = EnemyDamage;
        }
        if (EnemyId == "DistanceAttack")
        {
            
        }
    }
    public void AttackModeStop()
    {
        if (EnemyId == "Infanity")
        {
            gameObject.GetComponent<InfanityAttackBehavior>().StartCoroutine("StopAttack");
        }
        if (EnemyId == "DistanceAttack")
        {

        }
    }
}
