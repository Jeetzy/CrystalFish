using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MiniggameInteract : MonoBehaviour
{
    [Header("Detection")]
    public Transform player;
    public float activationRange = 3f;
    public float interactRange = 1.5f;

    [Header("UI")]
    public CanvasGroup interactUI; // “Press E to Interact”

    [Header("Scene Setup")]
    public string wireTaskScene = "WireTask1";  
    public Vector3 respawnLocationAfterReturn = new Vector3(640.3f, 25f, 366f);

    private bool triggered = false;
    private bool minigameDisabled = false;

    void Start()
    {
        // NEW — check if minigame was already done
        if (PlayerPrefs.GetString("MinigameDone", "no") == "yes")
        {
            minigameDisabled = true;
            interactUI.alpha = 0f;  // hide text forever
        }
    }

    void Update()
    {
        if (minigameDisabled || triggered)
            return;

        float dist = Vector3.Distance(player.position, transform.position);

        // Fade UI based on distance
        float alpha = Mathf.Clamp01(1 - (dist / activationRange));
        interactUI.alpha = alpha;

        if (dist < interactRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                triggered = true;
                BeginMinigame();
            }
        }
    }

    void BeginMinigame()
    {
        // Save that this minigame will be disabled after return
        PlayerPrefs.SetString("MinigameDone", "yes");

        // Save return respawn
        PlayerPrefs.SetString("ReturnScene", "Scrapyard");
        PlayerPrefs.SetFloat("RespawnX", respawnLocationAfterReturn.x);
        PlayerPrefs.SetFloat("RespawnY", respawnLocationAfterReturn.y);
        PlayerPrefs.SetFloat("RespawnZ", respawnLocationAfterReturn.z);

        PlayerPrefs.Save();

        // Load wire task scene
        SceneManager.LoadScene(wireTaskScene);
    }
}
