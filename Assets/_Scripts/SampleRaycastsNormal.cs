using UnityEngine;

public class SampleRaycastsNormal : MonoBehaviour
{
    public Transform objectToPlace;
    public Camera gameCamera;

    void Update()
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            objectToPlace.position = hit.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }
}
