using UnityEngine;
using UnityEngine.AI;

public class Phish : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent enemy;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player"); // find player
	    enemy = GetComponent<NavMeshAgent>(); // initialise nav mesh
	}
	
	// Update is called once per frame
	void Update ()
	{
	     enemy.destination = player.transform.position; // find player
	}
}
