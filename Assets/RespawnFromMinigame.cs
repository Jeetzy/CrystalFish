using UnityEngine;

public class RespawnFromMinigame : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("WireRespawnX"))
        {
            float x = PlayerPrefs.GetFloat("WireRespawnX");
            float y = PlayerPrefs.GetFloat("WireRespawnY");
            float z = PlayerPrefs.GetFloat("WireRespawnZ");

            transform.position = new Vector3(x, y, z);
        }
    }
}
