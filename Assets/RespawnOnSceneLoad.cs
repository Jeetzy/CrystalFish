using UnityEngine;

public class RespawnOnSceneLoad : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("RespawnX"))
        {
            float x = PlayerPrefs.GetFloat("RespawnX");
            float y = PlayerPrefs.GetFloat("RespawnY");
            float z = PlayerPrefs.GetFloat("RespawnZ");

            transform.position = new Vector3(x, y, z);

            // Clear respawn so it doesn't repeat
            PlayerPrefs.DeleteKey("RespawnX");
            PlayerPrefs.DeleteKey("RespawnY");
            PlayerPrefs.DeleteKey("RespawnZ");
            PlayerPrefs.DeleteKey("ReturnScene");
        }
    }
}
