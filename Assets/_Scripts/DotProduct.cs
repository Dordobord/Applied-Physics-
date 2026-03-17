using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public Transform player;
    public float fieldOfView = 45f;

    void Update()
    {
        CheckIfPlayerIsInFront();
        CheckFieldOfView();
    }

    private void CheckFieldOfView()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.position, toPlayer);

        float threshHold = Mathf.Cos(fieldOfView * Mathf.Deg2Rad);

        if (dot > threshHold)
        {
            Debug.Log("INSIDE of field view");
        }
        else
        {
            Debug.Log("OUTSIdE of field view");
        }
    }

    void CheckIfPlayerIsInFront()
    {
        Vector3 toPlayer = (player.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.position, toPlayer);

        float threshHold = Mathf.Cos(fieldOfView * Mathf.Deg2Rad);

        if (dot > 0)
        {
            Debug.Log("INSIDE of field view");
        }
        else
        {
            Debug.Log("OUTSIdE of field view");
        }
    }

    public bool HitFromFront(Vector3 hitDirection)
    {
        hitDirection.Normalize();
        float dot = Vector3.Dot(transform.forward, hitDirection);
        return dot > 0;
    }

    void OnDrawGizmos()
    {
        if (player == null) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 3);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, player.position);

        Gizmos.color = Color.yellow;
        Quaternion leftRot = Quaternion.Euler(0, -fieldOfView, 0);
        Quaternion rightRot = Quaternion.Euler(0, fieldOfView, 0);

        Gizmos.DrawLine(transform.position, transform.position + leftRot * transform.forward * 3);
        Gizmos.DrawLine(transform.position, transform.position + rightRot * transform.forward * 3);

    }
}
