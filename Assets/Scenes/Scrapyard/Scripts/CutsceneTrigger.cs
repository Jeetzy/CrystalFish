using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneTrigger : MonoBehaviour
{
    public Transform player;
    public float activationRange = 1.2f;

    public string cutsceneScene = "ShortScene";
    public string returnScene = "Scrapyard";
    public Vector3 returnPos = new Vector3(60.17f, 0f, 0f);

    private bool triggered = false;

    void Update()
    {
        if (triggered) return;

        if (Vector3.Distance(player.position, transform.position) < activationRange)
        {
            triggered = true;

            SceneSpawnManager.instance.SetRespawn(returnScene, returnPos);
            SceneManager.LoadScene(cutsceneScene);
        }
    }
}
