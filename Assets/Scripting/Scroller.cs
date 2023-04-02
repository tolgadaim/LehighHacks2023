using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scroller : MonoBehaviour
{
    [SerializeField]
    public bool IsActive = true;
    [SerializeField] [Tooltip ("Meters per second")]
    public float ScrollSpeed = 1;
    [SerializeField]
    public bool GenerateFish = true;
    [SerializeField]
    public float FishSpawnTime = 10f;
    [SerializeField]
    private GameObject fishPrefab;
    [SerializeField]
    private TextMeshProUGUI score;

    public float TotalScrolled = 0;
    public int PlatformsSpawned = 0;
    public int TimeIncreased = 0;
    public float TimeUntilNextFish = 0f;

    void Start()
    {
        if (GetComponent<IceRandomizer>() != null) {
            GetComponent<IceRandomizer>().StartingProcedure();
            PlatformsSpawned = 2;
        }
    }

    void Update()
    {
        if (IsActive) {
            foreach(Transform childTransform in GetComponentsInChildren<Transform>())
            {
                if (childTransform == transform)
                    continue;

                if (childTransform.parent != transform)
                    continue;

                childTransform.localPosition += new Vector3(0, 0, -ScrollSpeed * Time.deltaTime);
            }
            TotalScrolled += ScrollSpeed * Time.deltaTime;
            score.text = string.Format("{0:D2}", Mathf.RoundToInt(TotalScrolled));

            if (TimeUntilNextFish <= 0)
            {
                foreach (GameObject iceObject in GameObject.FindGameObjectsWithTag("Ice"))
                {
                    if (iceObject.name.Equals("IcePlatformWhole") && iceObject.transform.position.z >= 25 && iceObject.transform.position.x % 5 == 0)
                    {
                        Vector3 position = new Vector3(iceObject.transform.position.x, 0, iceObject.transform.position.z); 
                        SpawnFish(position, iceObject.transform);
                        break;
                    }
                }
                TimeUntilNextFish = FishSpawnTime;
            }

            if (TotalScrolled >= 25 * (PlatformsSpawned - 1))
            {
                if (GetComponent<IceRandomizer>() != null){
                    GetComponent<IceRandomizer>().SpawnNewGroup(new Vector3(0, -1, 50));
                }
                PlatformsSpawned++;
            }

            if (TotalScrolled >= 6 * (TimeIncreased + 1))
            {
                ScrollSpeed += 0.1f;
                TimeIncreased++;
            }

            TimeUntilNextFish -= Time.deltaTime;
        }
    }

    void SpawnFish(Vector3 position, Transform parent)
    {
        var fish = Instantiate(fishPrefab, position, Quaternion.Euler(0, 180, 0));
        fish.transform.parent = parent;
    }
}
