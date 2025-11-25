using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LadderCutscene : MonoBehaviour
{
    [Header("Ladder Object")]
    public Transform ladder;

    [Header("Positions")]
    public Vector3 startPos;
    public Vector3 endPos;

    [Header("Rotations")]
    public Vector3 startRot;
    public Vector3 endRot;

    [Header("Timing")]
    public float delayBeforeFall = 3f;
    public float fallDuration = 2f;

    [Header("Fade UI")]
    public CanvasGroup fadeUI;
    public float fadeDuration = 1.5f;

    [Header("Next Scene")]
    public string nextScene = "MainMenu";

    private bool isPlaying = false;

    public void Play()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayCutscene());
        }
    }

    IEnumerator PlayCutscene()
    {
        isPlaying = true;

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

        // Fade out
        float f = 0;
        while (f < fadeDuration)
        {
            f += Time.deltaTime;
            fadeUI.alpha = f / fadeDuration;
            yield return null;
        }

        SceneManager.LoadScene(nextScene);
    }
}