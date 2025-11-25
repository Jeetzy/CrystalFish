using UnityEngine;

public class ClearPlayerPrefsOnStart : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log(">>> ALL PLAYER PREFS CLEARED <<<");
    }
}
