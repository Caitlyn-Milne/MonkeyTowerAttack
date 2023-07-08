using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Splines;

public class MinionSpawner : MonoBehaviour
{
    public static MinionSpawner Instance;

    public Minion Prefab;
    private ObjectPool<Minion> pool;



    public void Spawn(MinionSpawnSetting settings)
    {
        StartCoroutine(SpawnCoroutine(settings));
    }

    public void ReleaseMinion(Minion minion)
    {
        pool.Release(minion);
    }

    private void Awake()
    {
        if (Instance is not null) 
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        pool = new ObjectPool<Minion> (
            CreateEmptyMinion,
            defaultCapacity: 100
        );
    }

    private Minion CreateEmptyMinion()
    {
        var minion = Instantiate(Prefab, transform);
        return minion;
    }

    private IEnumerator SpawnCoroutine(MinionSpawnSetting settings)
    {
        for (var i = 0; i < settings.Amount; ++i)
        {
            SpawnSingle(settings.MinionSettings);
            yield return new WaitForSeconds(1f / settings.Frequency);
        }
    }

    private void SpawnSingle(MinionSettings settings)
    {
        var minion = pool.Get();
        minion.Init(settings);
    }

}
