using UnityEngine;

public class ShootBall : MonoBehaviour
{
    private Camera gameCamera;

    [SerializeField] private GameObject bullePrefab;
    [SerializeField] private float shootForce = 50f;

    void Start()
    {
        gameCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            GameObject sphere = Instantiate(bullePrefab,gameCamera.transform.position,Quaternion.identity);

            ConstantForce force = sphere.GetComponent<ConstantForce>();

            if (force != null)
            {
                force.force = ray.direction * shootForce;
            }
        }
    }
}