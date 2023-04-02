using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IceRandomizer : MonoBehaviour
{
    [SerializeField]
    private Transform parentOfGroups;
    [SerializeField]
    public List<GameObject> IceGroups = new List<GameObject>();

    private GameObject lastGroup = null;

    public void StartingProcedure()
    {
        GetIceGroups();
        SpawnNewGroup(new Vector3(0, -1, 25));
        SpawnNewGroup(new Vector3(0, -1, 50));
    }

    public void GetIceGroups()
    {
        foreach (Transform child in parentOfGroups.GetComponentsInChildren<Transform>())
        {
            if (child.parent == parentOfGroups)
            {
                IceGroups.Add(child.gameObject);
            }
        }
        parentOfGroups.gameObject.SetActive(false);
    }

    // Returns lastGroup as GameObject or null if unable to spawn
    public GameObject SpawnNewGroup(Vector3 position)
    {
        if (IceGroups.Count == 0)
            return null;

        int randomGroupIndex = 0;
        while(true) {
            randomGroupIndex = Random.Range(0, IceGroups.Count);
            List<int> tryGroupStart = new List<int>();
            tryGroupStart = IceGroups[randomGroupIndex].GetComponent<IceGroup>().start;
            List<int> lastGroupEnd = new List<int>{1, 2, 3, 4, 5};
            if (lastGroup != null) {
                lastGroupEnd = lastGroup.GetComponent<IceGroup>().end;
            }

            List<int> intersection = tryGroupStart.Intersect(lastGroupEnd).ToList();
            if (intersection.Count > 0) {
                break;
            }
        }
        lastGroup = IceGroups[randomGroupIndex];
        var spawnedGroup = Instantiate(lastGroup, position, Quaternion.identity);
        spawnedGroup.SetActive(true);
        spawnedGroup.transform.parent = this.transform;
        return lastGroup;
    }
}
