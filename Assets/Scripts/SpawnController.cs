using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject target;

    [SerializeField] Vector3 spawnPosStart;
    [SerializeField] Vector3 spawnPosEnd;

    [SerializeField] Vector3 minAngle;
    [SerializeField] Vector3 maxAngle;

    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnTarget", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnTarget()
    {
        GameObject newTarget = ObjectPool.SharedInstance.GetPooledObject();
        if (newTarget != null)
        {
            newTarget.GetComponent<TargetMovementController>().setInitVel(GenerateRandomVector(minAngle, maxAngle, Random.Range(minSpeed, maxSpeed)));
            newTarget.transform.position = GenerateRandomVector(spawnPosStart, spawnPosEnd, 1);
            newTarget.SetActive(true);
        }
    }

    private Vector3 GenerateRandomVector(Vector3 start, Vector3 end, float multiplier)
    {
        Vector3 v = new Vector3(Random.Range(start.x, end.x), Random.Range(start.y, end.y), Random.Range(start.z, end.z)) * multiplier;
        return v;
    }
}
