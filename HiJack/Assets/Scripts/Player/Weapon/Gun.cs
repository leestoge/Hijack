using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 5f;
    public float range = 50f;
    public float fireRate = 10f;
    public LayerMask myLayerMask;
    public Animator playerAnim;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public GameObject enviornmentImpact;
    public GameObject enemyImpact;

    private float nextTimeToFire;


	// Update is called once per frame
	void Update ()
	{
        playerAnim = GetComponent<Animator>();

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
	    {
	        nextTimeToFire = Time.time + 1f / fireRate;
	        Shoot();
	    }
	}

    void Shoot()
    {
        playerAnim.SetTrigger("shoot");
        muzzleflash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range, myLayerMask))
        {
            Debug.Log(hitInfo.transform.name);

            targetPhish target = hitInfo.transform.GetComponent<targetPhish>();
            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject hitEnemy = Instantiate(enemyImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(hitEnemy, 2f);
            }
            else
            {
                GameObject impact = Instantiate(enviornmentImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impact, 2f);
            }
        }
    }
}
