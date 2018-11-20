using UnityEngine;

public class ShotgunSound : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetButtonDown("Fire1"))
	    {
	        FindObjectOfType<AudioManager>().Play("shootShotgun");
	    }
    }
}
