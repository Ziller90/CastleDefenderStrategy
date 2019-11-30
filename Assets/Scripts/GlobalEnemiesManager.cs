using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnemiesManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> EnemiesOnTheMap = new List<GameObject>();
    [SerializeField]
    float Distance;
    public float CastleRadius;
    public Vector3 CastlePosition;
    [SerializeField]
    List<GameObject> EnemiesInAttackRange = new List<GameObject>();
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void RegisterEnemy(GameObject Enemy)
    {
        EnemiesOnTheMap.Add(Enemy);
    }
    public void UnRegisterEnemy(GameObject Enemy)
    {
        EnemiesOnTheMap.Remove(Enemy);
    }
    public bool CanEnemyAttackCastle(Vector3 Enemy, float Range)
    {
        Distance = Vector3.Distance(Enemy, CastlePosition);
        if (Vector3.Distance(Enemy, CastlePosition) < Range + CastleRadius)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public GameObject EnemyToAttack(Vector3 TowerPosition, float AttackRange)
    {
        for (int i = 0; i < EnemiesOnTheMap.Count; i++)
        {
            if (TowerPosition.x + AttackRange > EnemiesOnTheMap[i].transform.position.x &&
                TowerPosition.x - AttackRange < EnemiesOnTheMap[i].transform.position.x &&
                TowerPosition.y + AttackRange > EnemiesOnTheMap[i].transform.position.y &&
                TowerPosition.y - AttackRange < EnemiesOnTheMap[i].transform.position.y &&
                TowerPosition.z + AttackRange > EnemiesOnTheMap[i].transform.position.z &&
                TowerPosition.z - AttackRange < EnemiesOnTheMap[i].transform.position.z)
            {
                return EnemiesOnTheMap[i];
            }
        }
        return null;
    }
    public bool IsEnemyAttackAble(GameObject Enemy, Vector3 TowerPosition, float AttackRange)
    {
        if (TowerPosition.x + AttackRange > Enemy.transform.position.x &&
            TowerPosition.x - AttackRange < Enemy.transform.position.x &&
            TowerPosition.y + AttackRange > Enemy.transform.position.y &&
            TowerPosition.y - AttackRange < Enemy.transform.position.y &&
            TowerPosition.z + AttackRange > Enemy.transform.position.z &&
            TowerPosition.z - AttackRange < Enemy.transform.position.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public GameObject EnemyToTurn (Vector3 WayPoint, int RouteNumber, int WayPointIndex)
    {
        for (int i = 0; i < EnemiesOnTheMap.Count; i++)
        {
            var EnemyBehaviour = EnemiesOnTheMap[i].GetComponent<EnemyBehaviour>();
            if (Vector3.Distance(EnemiesOnTheMap[i].transform.position, WayPoint) < 0.1f && EnemyBehaviour.RouteNumber == RouteNumber && EnemyBehaviour.WayIndex == WayPointIndex--)
            {
                return (EnemiesOnTheMap[i]);
            }
        }
        return (null);
    }
}
