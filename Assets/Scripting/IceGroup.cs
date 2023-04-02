using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGroup : MonoBehaviour
{
    [SerializeField]
    public List<int> start = new List<int>();
    [SerializeField]
    public List<int> end = new List<int>();

    void Update()
    {
        if (transform.position.z < -30f)
        {
            Destroy(gameObject);
        }
    }

}
