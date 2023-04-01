using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static bool GamePaused = false;

    public void PauseTime()
    {
        foreach(DriftingIce iceScript in GameObject.FindObjectsOfType<DriftingIce>())
        {
            iceScript.enabled = false;
        }
        GameObject.FindObjectOfType<Scroller>().IsActive = false;
        GameObject.FindObjectOfType<IceSinker>().IsActive = false;
        GameObject.FindObjectOfType<Player>().RestrictMovement = true;
        GameObject.FindObjectOfType<Player>().GetComponent<Rigidbody>().useGravity = false;
        GamePaused = true;
    }

    public void ResumeTime()
    {
        foreach(DriftingIce iceScript in GameObject.FindObjectsOfType<DriftingIce>())
        {
            iceScript.enabled = true;
        }
        GameObject.FindObjectOfType<Scroller>().IsActive = true;
        GameObject.FindObjectOfType<IceSinker>().IsActive = true;
        GameObject.FindObjectOfType<Player>().RestrictMovement = false;
        GameObject.FindObjectOfType<Player>().GetComponent<Rigidbody>().useGravity = true;
        GamePaused = false;
    }

    public bool CheckPaused()
    {
        return GamePaused;
    }
}
