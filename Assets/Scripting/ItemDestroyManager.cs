using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyManager : MonoBehaviour
{
    void FixedUpdate()
    {
        if (transform.position.y <= -10 || transform.position.z <= -25)
        {
            Destroy(gameObject);
        }
    }
}
