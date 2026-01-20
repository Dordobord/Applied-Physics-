using UnityEngine;

public class SampleRaycast : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] float dis = 100f;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, dis, mask, QueryTriggerInteraction.Ignore))
        {
            MeshRenderer mesh = hit.transform.GetComponent<MeshRenderer>();
            mesh.material.color = Color.red;
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * dis, Color.green);
        }
    }
}
