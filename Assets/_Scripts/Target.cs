using UnityEngine;

public class Target : MonoBehaviour
{
    private float distance = 5f;
    private float speed = 1f;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        Vector3 v = startPos;
        v.x += distance * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
