using UnityEngine;

public class DebugTools : MonoBehaviour
{
    public bool clearPrefsOnStart = false;

    void Start()
    {
        if (clearPrefsOnStart)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log(">>> ALL PLAYER PREFS CLEARED <<<");
        }
    }
}
