using UnityEngine;

public class GunSoundHandler : MonoBehaviour 
{

#region Variables
    private float totalTimeBeforeDestroy;
#endregion

	// Use this for initialization
	void Start ()
	{
	    var sound = this.GetComponent<AudioSource>();
	    totalTimeBeforeDestroy = sound.clip.length;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    totalTimeBeforeDestroy -= Time.deltaTime;

	    if (totalTimeBeforeDestroy <= 0f)
	    {
            Destroy(this.gameObject);
	    }
	}
}
