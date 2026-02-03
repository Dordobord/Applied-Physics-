using UnityEngine;

public class Rag : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] float dis = 100f;
    public Transform objectToPlace;
    public Camera gameCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, dis, mask, QueryTriggerInteraction.Ignore))
            {
                objectToPlace.position = hit.point;
                GetComponent<Animator>().enabled = false;
                Debug.DrawLine(ray.origin, hit.point, Color.red);

            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * dis, Color.green);
            }

        }

    }
}
