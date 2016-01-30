using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager>
{
    // guarantee this will be always a singleton only - can't use the constructor!
    protected GameManager() { }

}
