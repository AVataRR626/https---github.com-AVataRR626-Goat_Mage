using UnityEngine;
using System.Collections;

public class Pedestal : MonoBehaviour
{
    public GenericPickup myItem;
    public Transform itemNode;
    public Vector3 dropForce = new Vector3(0, 10, 0);
    public float dropColliderDelay = 0.5f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(myItem != null)
        {
            Pickup(myItem);

            myItem.GetComponent<AutokillTimer>().timer = 30;
        }
	}

    public void DropItem()
    {
        //check if you're already holding an object and drop it if you are
        if (myItem != null)
        {
            Rigidbody r0 = myItem.GetComponent<Rigidbody>();
            Collider c0 = myItem.GetComponent<Collider>();

            r0.useGravity = true;
            r0.isKinematic = false;
            r0.AddForce(dropForce);
            myItem.DelayedColliderEnable(dropColliderDelay);
            myItem.transform.parent = null;
            myItem = null;
        }
    }

    public void Pickup(GenericPickup pickup)
    {

        Rigidbody r = pickup.GetComponent<Rigidbody>();
        Collider c = pickup.GetComponent<Collider>();

        //check if the thing you bumped into is a pickupable
        if (r != null)
        {
            //drop any items you've got
            DropItem();

            pickup.transform.parent = transform;
            pickup.transform.position = itemNode.position;
            r.velocity = Vector3.zero;
            r.useGravity = false;
            r.isKinematic = false;
            c.enabled = false;

            myItem = pickup;


        }
    }
}
