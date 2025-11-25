using UnityEngine;

public class LadderCutsceneTrigger : MonoBehaviour
{
    public LadderCutscene cutsceneScript;

    public void TriggerLadderCutscene()
    {
        cutsceneScript.Play();
    }
}
