using UnityEngine;

public class Disappear : MonoBehaviour
{
    public GameObject[] bridge;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
