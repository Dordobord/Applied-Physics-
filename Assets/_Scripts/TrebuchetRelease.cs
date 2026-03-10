using UnityEngine;

public class TrebuchetRelease : MonoBehaviour
{
    [SerializeField] private Rigidbody projectile;
    [SerializeField] private float releaseAngle = 45;
    [SerializeField] private float currentAngle;

    private SpringJoint projectileJoint;
    private HingeJoint hinge;

    void Awake()
    {
        hinge = GetComponent<HingeJoint>();
        projectileJoint = projectile.GetComponent<SpringJoint>();
    }

    void Update()
    {
        currentAngle = hinge.angle;

        if (projectileJoint != null && currentAngle >= releaseAngle)
        {
            Destroy(projectileJoint);
        }
    }
}
