using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        // J.A.C.K sound clip?
        player.transform.position = respawnPoint.transform.position;
    }
}
