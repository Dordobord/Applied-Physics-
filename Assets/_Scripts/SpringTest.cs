using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class SpringTest : MonoBehaviour
{
    [SerializeField]private float force = 10f;
    [SerializeField]Transform anchor;

    private Rigidbody rb;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, anchor.position);
        line.SetPosition(1, transform.position);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse );
        }
    }

}
