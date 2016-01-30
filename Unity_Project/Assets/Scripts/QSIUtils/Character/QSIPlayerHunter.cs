using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class QSIPlayerHunter : MonoBehaviour
{
    public string targetTag = "Player";
    public GameObject target;

    public NavMeshAgent navAgent;

	// Use this for initialization
	void Start ()
    {
        navAgent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            target = GenUtils.FindClosestWithTag(transform.position, targetTag);
            navAgent.destination = target.transform.position;

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
        if(target != null)
            navAgent.destination = target.transform.position;
        else
            target = GenUtils.FindClosestWithTag(transform.position, targetTag);
    }
}
