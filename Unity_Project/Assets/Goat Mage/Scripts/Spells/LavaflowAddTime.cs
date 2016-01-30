using UnityEngine;
using System.Collections;

public class LavaflowAddTime : MonoBehaviour
{
    public float time;
    public bool destroyAfterEffect = true;

    // Use this for initialization
    void Start ()
    {
        LavaManager.Instance.AddTimeLeft(time);

        if (destroyAfterEffect)
            Destroy(gameObject);
	}
	
}
