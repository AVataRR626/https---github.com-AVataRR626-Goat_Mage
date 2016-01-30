using UnityEngine;
using System.Collections;

public class ExitProgram : MonoBehaviour {

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
