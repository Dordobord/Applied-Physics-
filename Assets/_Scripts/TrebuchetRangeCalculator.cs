using System;
using UnityEngine;

public class TrebuchetRangeCalculator : MonoBehaviour
{
    [SerializeField] private Rigidbody projectile;

    public bool calculateOnlyPress = true;

    void Update()
    {
        if (calculateOnlyPress && Input.GetKeyDown(KeyCode.Space))
        {
            float predictedRange = CalculateExpectedRange(projectile.linearVelocity, projectile.transform.position.y);

            Debug.Log("Predicted Range: " + predictedRange.ToString("F2") + "meters");
        }
    }

    private float CalculateExpectedRange(Vector3 launchVelocity, float launchHeight)
    {
        float g = Mathf.Abs(Physics.gravity.y);

        float vx = launchVelocity.x;
        float vz = launchVelocity.z;

        float horizontalSpeed = new Vector2(vx, vz).magnitude;

        float vy = launchVelocity.y;
        float discriminant = (vy * vy) + (2 * g * launchHeight);

        if (discriminant < 0)
        {
            return 0f;
        }

        float time = (vy + Mathf.Sqrt(discriminant)) / g;

        float range = horizontalSpeed + time;

        return range;
    }
}
