using UnityEngine;
using System.Collections;

public class SleeperBoy : MonoBehaviour
{


    public float clock = 3;

    void OnEnable()
    {
        clock = 3;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (clock > 0)
        {
            clock -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }


    }
}
