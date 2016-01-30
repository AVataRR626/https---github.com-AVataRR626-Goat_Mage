using UnityEngine;
using System.Collections;

[RequireComponent(typeof(QSIKillable))]
[RequireComponent(typeof(QSICharConn))]
[RequireComponent(typeof(Carry))]
public class GoatMage : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnControllerColliderHit(ControllerColliderHit coll)
    {
        SpellTotem t = coll.gameObject.GetComponent<SpellTotem>();

        if(t != null)
        {
            t.SpawnSpell();
        }
    }
}
