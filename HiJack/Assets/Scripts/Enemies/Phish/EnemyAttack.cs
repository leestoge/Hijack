using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            print("enter trigger with _player");
           Attack();
            print("attempting to do damage");
        }
    }

    private void Attack()
    {
        PlayerHealth playerDamage = player.GetComponent<PlayerHealth>();
        if (playerDamage != null)
        {
            playerDamage.TakeDamage(5f); // reduced damage to 5
        }
    }
}