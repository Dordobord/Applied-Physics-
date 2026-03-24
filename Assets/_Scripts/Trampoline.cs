using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private float force = 50f;
    [SerializeField] Rigidbody player;

    private Rigidbody rb;
    private Collider col;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            player.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
