using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSinker : MonoBehaviour
{
    [SerializeField]
    private float zPosSinkingPoint = -20.0f;
    [SerializeField]
    private float minYPoint = -5.0f;
    [SerializeField]
    private float sinkingSpeed = 2.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject iceObject in GameObject.FindGameObjectsWithTag("Ice")) {

            if (iceObject.transform.IsChildOf(transform) == false)
                continue;

            if (iceObject.transform.position.z <= zPosSinkingPoint && iceObject.transform.position.y >= minYPoint) {
                iceObject.transform.position += new Vector3(0, -sinkingSpeed * FindObjectOfType<Scroller>().ScrollSpeed * Time.fixedDeltaTime, 0);
            } else if (iceObject.transform.position.y <= minYPoint) {
                Destroy(iceObject);
            }
        }
    }
}
