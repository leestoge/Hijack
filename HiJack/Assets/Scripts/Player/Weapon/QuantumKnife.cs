﻿using UnityEngine;

public class QuantumKnife : MonoBehaviour
{
    public Camera fpsCam;
    public float distance; // 5 is good
    public int damage; // 10 ?
    public LayerMask myLayerMask;
    public Animator playerAnim;

    public float swingRate = 1.3f;
    private float nextTimeToSwing;

    // Update is called once per frame
    void Update ()
	{
        playerAnim = GetComponent<Animator>();

        if (Input.GetButton("Fire1"))
        {
            playerAnim.SetTrigger("Attack");
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToSwing)
	    {
            nextTimeToSwing = Time.time + 1f / swingRate;
	        FindObjectOfType<AudioManager>().Play("SwordSwing");
            Slash();
	    }
	}

    void Slash()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, distance, myLayerMask))
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
