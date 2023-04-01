using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftingIce : MonoBehaviour
{
    [SerializeField]
    private float xRestartPoint = -30.0f;
    [SerializeField]
    private bool isGoingUp = true;
    [SerializeField]
    private float driftingSpeed = 2.0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform childTransform in GetComponentsInChildren<Transform>()) {
            if (childTransform == transform)
                continue;

            int signValue = 1;
            if (isGoingUp) {
                signValue = -1;
            }

            childTransform.position += new Vector3(signValue * driftingSpeed * FindObjectOfType<Scroller>().ScrollSpeed * Time.fixedDeltaTime, 0, 0);
            if (Mathf.Abs(childTransform.position.x) > xRestartPoint) {
                childTransform.position = new Vector3(-1 * Mathf.Sign(childTransform.position.x) * xRestartPoint, childTransform.position.y, childTransform.position.z);
            }
        }
    }
}
