using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTrigger : MonoBehaviour
{
    [Header("Detection")]
    public Transform player;
    public float activationDistance = 1.2f;

    [Header("Scenes")]
    public string cutsceneScene = "ShortScene";
    public string returnScene = "Scrapyard";

    [Header("Respawn Location When Returning")]
    public Vector3 respawnPos = new Vector3(60.17f, 0f, 0f);

    private bool triggered = false;

    void Update()
    {
        if (triggered) return;

        float dist = Vector3.Distance(player.position, transform.position);

        if (dist < activationDistance)
        {
            triggered = true;
            TriggerCutscene();
        }
    }

    void TriggerCutscene()
    {
        // Save where to return & respawn
        PlayerPrefs.SetString("ReturnScene", returnScene);
        PlayerPrefs.SetFloat("RespawnX", respawnPos.x);
        PlayerPrefs.SetFloat("RespawnY", respawnPos.y);
        PlayerPrefs.SetFloat("RespawnZ", respawnPos.z);

        PlayerPrefs.Save();

        // Load the cutscene scene
        SceneManager.LoadScene(cutsceneScene);
    }
}
