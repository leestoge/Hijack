using DG.Tweening;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shotgunModel;
    public float damage;
    public float range;
    public float fireRate;
    public LayerMask myLayerMask;
    public Animator playerAnim;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public GameObject enviornmentImpact;
    public GameObject enemyImpact;

    private float nextTimeToFire;

    [Space]

    public float punchStrenght = .2f;
    public int punchVibrato = 5;
    public float punchDuration = .3f;
    [Range(0, 1)]
    public float punchElasticity = .5f;


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
        shotgunModel.DOComplete();
        shotgunModel.DOPunchPosition(new Vector3(0, 0, -punchStrenght), punchDuration, punchVibrato, punchElasticity);
        muzzleflash.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range, myLayerMask))
        {
            Debug.Log(hitInfo.transform.name);

            Phish target = hitInfo.transform.GetComponent<Phish>();
            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject hitEnemy = Instantiate(enemyImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(hitEnemy, 0.5f);
            }
            else
            {
                GameObject impact = Instantiate(enviornmentImpact, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(impact, 0.5f);
            }
        }
        FindObjectOfType<AudioManager>().Play("shootShotgun");
    }
}
