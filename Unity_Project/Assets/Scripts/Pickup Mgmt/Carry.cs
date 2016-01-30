using UnityEngine;
using System.Collections;

public class Carry : MonoBehaviour
{
    public Transform pickupNode;
    public string pickupTag = "Pickup";
    public Vector3 dropForce = new Vector3(0, 10, 0);
    public float dropColliderDelay = 1f;

    private GenericPickup myPickup;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //manage your pickup
        if(myPickup != null)
        {
            myPickup.transform.position = pickupNode.position;
            myPickup.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit coll)
    {
        //Debug.Log("Carry: HIT:" + coll.gameObject.name);

        //handle pickups
        GenericPickup pup = coll.gameObject.GetComponent<GenericPickup>();
        if (pup != null)
        {
            Debug.Log("CarrY: ITS AN PICKUPABLE!!");
            Pickup(pup);
        }

        //check if its a pedestal and handle it
        Pedestal ptl = coll.gameObject.GetComponent<Pedestal>();
        if (ptl != null)
        {
            Debug.Log("CarrY: ITS A PEDESTAL!");
            PedestalPlace(ptl);
        }
    }

    void PedestalPlace(Pedestal p)
    {
        if(myPickup != null)
        {
            p.Pickup(myPickup);            
            DropItem();
        }
    }

    public void DropItem()
    {
        //check if you're already holding an object and drop it if you are
        if (myPickup != null)
        {
            Rigidbody r0 = myPickup.GetComponent<Rigidbody>();
            Collider c0 = myPickup.GetComponent<Collider>();

            r0.useGravity = true;
            r0.isKinematic = false;
            r0.AddForce(dropForce);
            myPickup.DelayedColliderEnable(dropColliderDelay);
            myPickup.transform.parent = null;
            myPickup = null;

        }
    }

    public void Pickup(GenericPickup pickup)
    {   
        
        Rigidbody r = pickup.GetComponent<Rigidbody>();
        Collider c = pickup.GetComponent<Collider>();

        //check if the thing you bumped into is a pickupable
        if (pickup.tag == pickupTag && r != null)
        {
            //drop any items you've got
            DropItem();

            pickup.transform.parent = transform;
            pickup.transform.position = pickupNode.position;
            r.velocity = Vector3.zero;
            r.useGravity = false;
            r.isKinematic = false;
            c.enabled = false;

            myPickup = pickup;
            

        }
    }

}
