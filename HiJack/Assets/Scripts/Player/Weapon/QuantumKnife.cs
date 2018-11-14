using UnityEngine;

public class QuantumKnife : MonoBehaviour
{
    public Camera fpsCam;
    public float distance;
    public LayerMask myLayerMask;
    public int damage;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetButtonDown("Fire1"))
	    {
	        Slash();
	    }
	}

    void Slash()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, distance, myLayerMask))
        {
            targetPhish target = hit.transform.GetComponent<targetPhish>();
            if (target != null)
            {
                Debug.Log("Enemy hit");
            }
            Debug.Log(hit.transform.name);
        }
    }
}
