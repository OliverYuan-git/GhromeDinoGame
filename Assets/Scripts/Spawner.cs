using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnObject
    {
        public GameObject prefab;
        [Range(0f,1f)]
        public float spawnChance;

    }

    public SpawnObject[] objects;

    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (var obj in objects)
        {
            if(spawnChance < obj.spawnChance)
            {
                GameObject Collision = Instantiate(obj.prefab);
                Collision.transform.position += transform.position;
                break;
            }

            spawnChance -= obj.spawnChance;
        }

        Invoke(nameof(Spawn), Random.Range(minSpawnRate,maxSpawnRate));
    }
}
