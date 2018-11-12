using UnityEngine;

public class Scrubber : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;
    public Transform player;
	// Use this for initialization
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player").transform;

	    //timeBetweenShots = startTimeBetweenShots;
	}
	
	// Update is called once per frame
	void Update ()
	{
        transform.LookAt(player); // acts like a crab for some reason

	    if(Vector3.Distance(transform.position, player.position) > stoppingDistance)
	    {
	        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
	    }
        else if(Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
	    {
	        transform.position = this.transform.position;
	    }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
	    {
	        transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

	    //if (timeBetweenShots <= 0)
	    //{
	    //    Instantiate(projectile, transform.position, Quaternion.identity);
	    //    timeBetweenShots = startTimeBetweenShots;
	    //}
	    //else
	    //{
	    //    timeBetweenShots -= Time.deltaTime;
	    //}
	}
}
