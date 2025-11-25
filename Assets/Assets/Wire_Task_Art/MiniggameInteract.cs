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
    public CanvasGroup interactUI;

    [Header("Scene Setup")]
    public string wireTaskScene = "WireTask1";
    public Vector3 returnPlayerPosition = new Vector3(640.3f, 25f, 366f);

    private bool triggered = false;

    void Start()
    {
        interactUI.alpha = 0;
        
        // Disable the minigame forever after completion
        if (SceneSpawnManager.instance.HasCompleted("WireTask"))
        {
            interactUI.alpha = 0;
            this.enabled = false;
        }
    }

    void Update()
    {
        if (triggered) return;

        float dist = Vector3.Distance(player.position, transform.position);

        // Fade UI based on distance
        interactUI.alpha = Mathf.Clamp01(1 - (dist / activationRange));

        // Press E to start minigame
        if (dist < interactRange && Input.GetKeyDown(KeyCode.E))
        {
            triggered = true;
            StartMinigame();
        }
    }

    void StartMinigame()
    {
        // Set spawn after returning from minigame
        SceneSpawnManager.instance.SetRespawn("Scrapyard", returnPlayerPosition);

        // Mark minigame as completed for future checks
        SceneSpawnManager.instance.MarkCompleted("WireTask");

        SceneManager.LoadScene(wireTaskScene);
    }
}