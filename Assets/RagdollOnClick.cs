using UnityEngine;

public class Rag : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] float dis = 100f;
    public Camera gameCamera;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, dis, mask, QueryTriggerInteraction.Ignore))
            {
                Animator anim = hit.collider.GetComponent<Animator>();
                anim.enabled = false;
            }

        }

    }
}
