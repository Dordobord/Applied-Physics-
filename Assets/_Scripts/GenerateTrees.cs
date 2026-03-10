using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    public float radius = 20f;
    public float distance = 10f;
    public int maxObjectsToSpawn = 15;
    private List<GameObject> spawnedObj = new List<GameObject>();
    public GameObject treePrefab;
    public LayerMask layerMask;

    void Update()
    {
        if (spawnedObj.Count < maxObjectsToSpawn)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(2f, 5f);
            float z = Random.Range(-10f, 10f);

            transform.position = new Vector3(x, y, z);
            
            Ray ray = new Ray(transform.position, Vector2.down);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distance, layerMask, QueryTriggerInteraction.Collide))
            {
                GameObject finalObj = Instantiate(treePrefab, hit.point, Quaternion.identity);
                spawnedObj.Add(finalObj);
            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.green);
            }
        }
    }
}
