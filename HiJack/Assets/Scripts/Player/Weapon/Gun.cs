using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;

    private float nextTimeToFire = 0f;


	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
	    {
	        nextTimeToFire = Time.time + 1f / fireRate;
	        Shoot();
	    }
	}

    void Shoot()
    {
        muzzleflash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            targetPhish target = hitInfo.transform.GetComponent<targetPhish>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
