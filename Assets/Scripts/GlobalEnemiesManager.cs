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
        for (int i = 0; i < EnemiesOnTheMap.Count; i++)
        {
            var EnemyBehaviour = EnemiesOnTheMap[i].GetComponent<EnemyBehaviour>();
            if (Vector3.Distance(EnemiesOnTheMap[i].transform.position, CastlePosition) < EnemyBehaviour.AttackRange + CastleRadius)
            {
                EnemyBehaviour.Attack();
            }
        }
    }
    public void RegisterEnemy(GameObject Enemy)
    {
        EnemiesOnTheMap.Add(Enemy);
    }
    public void UnRegisterEnemy(GameObject Enemy)
    {
        EnemiesOnTheMap.Remove(Enemy);
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
    public bool IsEnemyInRadius(Vector3 ObjectPosition, float Range)
    {
        for (int i = 0; i < EnemiesOnTheMap.Count; i++)
        {
            if (ObjectPosition.x + Range > EnemiesOnTheMap[i].transform.position.x &&
                ObjectPosition.x - Range < EnemiesOnTheMap[i].transform.position.x &&
                ObjectPosition.y + Range > EnemiesOnTheMap[i].transform.position.y &&
                ObjectPosition.y - Range < EnemiesOnTheMap[i].transform.position.y &&
                ObjectPosition.z + Range > EnemiesOnTheMap[i].transform.position.z &&
                ObjectPosition.z - Range < EnemiesOnTheMap[i].transform.position.z)
            {
                return true;
            }
        }
        return false;
    }
    public List<GameObject> EnemiesInRadius(Vector3 ObjectPosition, float Range)
    {
        List<GameObject> EnemiesDetected = new List<GameObject>();
        for (int i = 0; i < EnemiesOnTheMap.Count; i++)
        {
            if (ObjectPosition.x + Range > EnemiesOnTheMap[i].transform.position.x &&
                ObjectPosition.x - Range < EnemiesOnTheMap[i].transform.position.x &&
                ObjectPosition.y + Range > EnemiesOnTheMap[i].transform.position.y &&
                ObjectPosition.y - Range < EnemiesOnTheMap[i].transform.position.y &&
                ObjectPosition.z + Range > EnemiesOnTheMap[i].transform.position.z &&
                ObjectPosition.z - Range < EnemiesOnTheMap[i].transform.position.z)
            {
                EnemiesDetected.Add(EnemiesOnTheMap[i]);
            }
        }
        if (EnemiesDetected != null)
        {
            return EnemiesDetected;
        }
        else
        {
            return null;
        }
    }

}
