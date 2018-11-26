using UnityEngine;

public class QuantumKnife : MonoBehaviour
{
    public Camera fpsCam;
    public float distance; // 5 is good
    public int damage; // 10 ?
    public LayerMask myLayerMask;
    public Animator playerAnim;

    public GameObject enviornmentImpact;
    public GameObject enemyImpact;

    public float swingRate = 1.3f;
    private float nextTimeToSwing;

    // Update is called once per frame
    void Update ()
	{
        playerAnim = GetComponent<Animator>();

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToSwing)
	    {
            nextTimeToSwing = Time.time + 1f / swingRate;
	        FindObjectOfType<AudioManager>().Play("SwordSwing");
            Slash();
	    }
	}

    void Slash()
    {
        playerAnim.SetTrigger("Attack");
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, distance, myLayerMask))
        {
            Debug.Log(hitInfo.transform.name);

            Phish target = hitInfo.transform.GetComponent<Phish>();
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
