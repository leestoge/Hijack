using UnityEngine;

public class MachineGun : MonoBehaviour
{

#region Variables
    public float damage = 5f;
    public float range = 50f;
    public float fireRate = 10f;
    public LayerMask myLayerMask;
    public Animator playerAnim;

    public Camera fpsCam;
    public ParticleSystem muzzleflash;
    public GameObject enviornmentImpact;
    public GameObject enemyImpact;
    public GameObject Gunshot;

    private float nextTimeToFire;
    private int framesBeforeNextShot; // to delay the sound to fix lag increment this
    private int currentShotFrame;
    #endregion

    // Update is called once per frame
    void Update()
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

        if (currentShotFrame == 0)
        {
            GameObject gunShot = Instantiate(Gunshot, this.transform.position, this.transform.rotation);
            gunShot.transform.parent = this.transform;
            currentShotFrame = framesBeforeNextShot;
        }
        else
        {
            currentShotFrame--;
        }
    }
}
