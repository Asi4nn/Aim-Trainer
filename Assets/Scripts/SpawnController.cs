using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject target;

    [SerializeField] float spawnDelay;
    [SerializeField] float spawnRate;

    [SerializeField] List<List<Vector3>> spawnLocationList;
    [SerializeField] List<List<Vector3>> spawnAngleList;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // sample data
        spawnLocationList = new List<List<Vector3>>
        {
            new List<Vector3> 
            { 
                new Vector3(-20, 5, 40), new Vector3(20, 10, 40) 
            }
        };

        spawnAngleList = new List<List<Vector3>>
        {
            new List<Vector3>
            {
                new Vector3(-1, 1, -1), new Vector3(1, 1, -1)
            }
        };

        InvokeRepeating("SpawnTarget", spawnDelay, spawnRate);
    }

    void SpawnTarget()
    {
        GameObject newTarget = ObjectPool.SharedInstance.GetPooledObject();
        if (newTarget != null)
        {
            newTarget.transform.position = GenerateRandomVector(spawnLocationList, 1);
            newTarget.GetComponent<TargetMovementController>().setInitVel(GenerateRandomVector(spawnAngleList, Random.Range(minSpeed, maxSpeed)));
            newTarget.SetActive(true);
        }
    }

    private Vector3 GenerateRandomVector(Vector3 start, Vector3 end, float multiplier)
    {
        Vector3 v = new Vector3(Random.Range(start.x, end.x), Random.Range(start.y, end.y), Random.Range(start.z, end.z)) * multiplier;
        return v;
    }

    private Vector3 GenerateRandomVector(List<List<Vector3>> lst, float multiplier)
    {
        int index = Random.Range(0, lst.Count);

        return GenerateRandomVector(lst[index][0], lst[index][1], multiplier);
    }
}
