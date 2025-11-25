using UnityEngine;

public class SceneSpawnManager : MonoBehaviour
{
    public static SceneSpawnManager instance;

    // Stores 1 respawn per load
    private static Vector3? nextRespawnPosition = null;
    private static string nextRespawnScene = "";
    private static string completionFlag = "";

    void Awake()
    {
        instance = this;

        // Move player to respawn spot if configured
        if (nextRespawnPosition.HasValue && 
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == nextRespawnScene)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                player.transform.position = nextRespawnPosition.Value;

            nextRespawnPosition = null;
            nextRespawnScene = "";
        }

        // NEW: Trigger the ladder cutscene when coming from the minigame
        if (completionFlag == "WireTask")
        {
            LadderCutsceneTrigger trigger = FindObjectOfType<LadderCutsceneTrigger>();
            if (trigger != null)
                trigger.TriggerLadderCutscene();

            // clear so it doesn't play again
            completionFlag = "";
        }
    }


    // Scene caller before loading
    public void SetRespawn(string sceneName, Vector3 position, string completeFlag = "")
    {
        nextRespawnPosition = position;
        nextRespawnScene = sceneName;
        completionFlag = completeFlag;
    }

    public bool HasCompleted(string flag)
    {
        return completionFlag == flag;
    }

    public void MarkCompleted(string flag)
    {
        completionFlag = flag;
    }
}
