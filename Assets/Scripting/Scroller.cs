using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField]
    private bool isActive = true;
    [SerializeField] [Tooltip ("Meters per second")]
    public float ScrollSpeed = 1;

    public float TotalScrolled = 0;
    public int PlatformsSpawned = 0;

    void Start()
    {
        if (GetComponent<IceRandomizer>() != null) {
            GetComponent<IceRandomizer>().StartingProcedure();
            PlatformsSpawned = 2;
        }
    }

    void FixedUpdate()
    {
        if (isActive) {
            foreach(Transform childTransform in GetComponentsInChildren<Transform>())
            {
                if (childTransform == transform)
                    continue;

                if (childTransform.parent != transform)
                    continue;

                childTransform.localPosition += new Vector3(0, 0, -ScrollSpeed * Time.fixedDeltaTime);
            }
            TotalScrolled += ScrollSpeed * Time.fixedDeltaTime;
        }

        if (TotalScrolled >= 25 * (PlatformsSpawned - 1))
        {
            Debug.Log("Spawned Ice");
            if (GetComponent<IceRandomizer>() != null)
            GetComponent<IceRandomizer>().SpawnNewGroup(new Vector3(0, 0, 50));
            PlatformsSpawned++;
        }
    }
}
