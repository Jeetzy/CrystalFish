using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LadderCutscene : MonoBehaviour
{
    [Header("Ladder Object")]
    public Transform ladder;

    [Header("Positions")]
    public Vector3 startPos = new Vector3(645.3f, 34.04f, 363.38f);
    public Vector3 endPos = new Vector3(645.4f, 26.02f, 358.67f);

    [Header("Rotations")]
    public Vector3 startRot = new Vector3(-90f, 0f, 0f);
    public Vector3 endRot = new Vector3(0.055f, 0f, 0f);

    [Header("Timing")]
    public float delayBeforeFall = 3f;
    public float fallDuration = 2f;

    [Header("Fade UI")]
    public CanvasGroup fadeUI; // Black screen
    public float fadeDuration = 1.5f;

    [Header("Next Scene")]
    public string nextScene = "MainMenu";

    private bool hasPlayed = false;

    void Start()
    {
        if (PlayerPrefs.GetString("MinigameDone", "no") == "yes")
        {
            StartCoroutine(PlayCutscene());
        }
    }

    public static void MarkReturn()
{
    PlayerPrefs.SetString("ReturnScenePlayed", "yes");
    PlayerPrefs.SetString("MinigameDone", "yes"); 
    PlayerPrefs.Save();
}


    IEnumerator PlayCutscene()
    {
        ladder.position = startPos;
        ladder.rotation = Quaternion.Euler(startRot);

        yield return new WaitForSeconds(delayBeforeFall);

        float t = 0;
        while (t < fallDuration)
        {
            t += Time.deltaTime;
            float lerp = t / fallDuration;

            ladder.position = Vector3.Lerp(startPos, endPos, lerp);
            ladder.rotation = Quaternion.Euler(Vector3.Lerp(startRot, endRot, lerp));

            yield return null;
        }

        // Fade to black
        float fade = 0f;
        while (fade < fadeDuration)
        {
            fade += Time.deltaTime;
            fadeUI.alpha = fade / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}
