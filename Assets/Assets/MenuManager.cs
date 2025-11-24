using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string playSceneName = "GameScene";  // Editable in Inspector

    public void PlayGame()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
