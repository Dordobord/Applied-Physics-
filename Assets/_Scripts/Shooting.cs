using System;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] LayerMask mask;
    [SerializeField] float dis = 100f;
    public Transform objectToPlace;
    public Camera gameCamera;   
    private float score = 0;

    public TextMeshProUGUI scoreTxt;

    void Start()
    {
        Score();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, dis, mask, QueryTriggerInteraction.Ignore))
            {
                objectToPlace.position = hit.point;

                MeshRenderer mesh = hit.transform.GetComponent<MeshRenderer>();
                mesh.material.color = Color.red;
                Debug.DrawLine(ray.origin, hit.point, Color.red);

                Debug.Log(AddScore(hit.distance));

                Destroy(hit.collider.gameObject);

            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * dis, Color.green);
            }

        }

    }

    public void Score()
    {
        Debug.Log("CurrentScore:" + score);
    }

    private float AddScore(float points)
    {
        score += points;
        scoreTxt.text = "Score:" + score;
        Math.Ceiling(score);
        return score;
    }
}
