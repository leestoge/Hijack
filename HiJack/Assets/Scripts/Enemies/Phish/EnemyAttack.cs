using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject _player;
    private bool _collidedWithPlayer;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            print("enter trigger with _player");
            _collidedWithPlayer = true;
            print("attempting to do damage");
        }    
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == _player)
        {
            _collidedWithPlayer = true;
        }
        print("enter collided with _player");
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == _player)
        {
            _collidedWithPlayer = false;
        }
        print("exit collided with _player");
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            print("exit trigger with _player");
            _collidedWithPlayer = false;
        }      
    }

    private void Attack()
    {
        if (_collidedWithPlayer)
        {
            _player.GetComponent<PlayerHealth>().TakeDamage(10);
        }
    }
}