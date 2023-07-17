using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Food;
    public GameObject[] Enemy;
    public List<GameObject> SpawnedObjects;
    static SpawnController instance;
    public Transform[] EnemySpawnPoints;
    public Transform[] FoodSpawnPoints;
    public float SpawnTimerMin = 1;
    public float SpawnTimerMax = 2;
    float InstantiateTimer;
    public int MaxEnemyCount = 3;

    bool GameInProgress;
    public static SpawnController Instance
    {
        get { return instance; }
        private set { instance = value; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    GameObject GetRandomEnemy()
    {
        return Enemy[Random.Range(0, Enemy.Length)];
    }
    Transform GetRandomSpawnPointForFood()
    {
        return FoodSpawnPoints[Random.Range(0, FoodSpawnPoints.Length)];
    }
    Transform GetRandomSpawnPointForEnemy()
    {
        return EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Length)];
    }
    void SpawnHere(GameObject obj,Transform point) 
    {
        GameObject go=(GameObject)Instantiate(obj, point.position, point.rotation);
        SpawnedObjects.Add(go);
    }
    public void Despawn(GameObject go)
    {
        SpawnedObjects.Remove(go);
        Destroy(go);
    }
    private void Update()
    {
        if (MenuController.Instance.IsGameInProgress) 
        {
            GameInProgress = true;
            if (InstantiateTimer < Time.time)
            {
                InstantiateTimer = Time.time + Random.Range(SpawnTimerMin, SpawnTimerMax);
                int EnemyCount = Random.Range(0, MaxEnemyCount + 1);
                for (int i = 0; i < EnemyCount; i++)
                {
                    SpawnHere(GetRandomEnemy(), GetRandomSpawnPointForEnemy());
                }

                SpawnHere(Food, GetRandomSpawnPointForFood());
            }
        }
        else 
        {
            if (GameInProgress)
            {
                GameInProgress = false;
                foreach (GameObject go in SpawnedObjects)
                {
                    if (go != null)
                    {
                        Destroy(go);
                    }
                }
                SpawnedObjects.Clear();
            }
        }
    }
}
