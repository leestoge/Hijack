using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 5f;
    public float range = 50f;
    public float fireRate = 10f;
    public LayerMask myLayerMask;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;

    private float nextTimeToFire;


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
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range, myLayerMask))
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
