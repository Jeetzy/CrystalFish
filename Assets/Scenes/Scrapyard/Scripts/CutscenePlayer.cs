using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutscenePlayer : MonoBehaviour
{
    [Header("Video Settings")]
    public VideoPlayer videoPlayer;

    [Header("Next Scene After Video")]
    public string returnScene = "Scrapyard";

    void Start()
    {
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.loopPointReached += OnVideoEnd;

        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(returnScene);
    }
}
