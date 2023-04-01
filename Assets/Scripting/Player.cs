using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int movementLength = 1;
    [SerializeField]
    private int maxHunger = 15;

    private float hunger;

    private bool restrictMovement;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Water")
        {
            Death();
        }

        if (other.gameObject.tag == "Food")
        {
            hunger = Mathf.Min(hunger + 10.0f, maxHunger);
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        hunger = maxHunger;
    }

    void Update()
    {
        if (hunger <= 0)
        {
            Death();
        }

        if (restrictMovement != true)
        {
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                Jump();
                for (int i = 1; i <= movementLength; i++) {
                    Invoke("MoveUp", Time.fixedDeltaTime * i);
                }
                Invoke("Fall", Time.fixedDeltaTime * (movementLength + 1));
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                Jump();
                for (int i = 1; i <= movementLength; i++) {
                    Invoke("MoveDown", Time.fixedDeltaTime * i);
                }
                Invoke("Fall", Time.fixedDeltaTime * (movementLength + 1));
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                Jump();
                for (int i = 1; i <= movementLength; i++) {
                    Invoke("MoveRight", Time.fixedDeltaTime * i);
                }
                Invoke("Fall", Time.fixedDeltaTime * (movementLength + 1));
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Jump();
                for (int i = 1; i <= movementLength; i++) {
                    Invoke("MoveLeft", Time.fixedDeltaTime * i);
                }
                Invoke("Fall", Time.fixedDeltaTime * (movementLength + 1));
            }
        }
        
        hunger -= Time.deltaTime;
    }

    void Death()
    {
        Debug.Log("Polar Bear Died");
        restrictMovement = true;
    }

    void MoveUp()
    {
        transform.localEulerAngles = new Vector3(0, -90, 0); 
        transform.localPosition += new Vector3(-5f/movementLength, 0, 0);
    }

    void MoveDown()
    {
        transform.localEulerAngles = new Vector3(0, 90, 0); 
        transform.localPosition += new Vector3(5f/movementLength, 0, 0);
    }

    void MoveRight()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0); 
        transform.localPosition += new Vector3(0, 0, 5f/movementLength);
    }

    void MoveLeft()
    {
        transform.localEulerAngles = new Vector3(0, 180, 0); 
        transform.localPosition += new Vector3(0, 0, -5f/movementLength);
    }

    void Jump()
    {
        transform.localPosition += new Vector3(0, 0.5f, 0);
        restrictMovement = true;
    }

    void Fall()
    {
        transform.localPosition += new Vector3(0, -0.5f, 0);
        restrictMovement = false;
    }
}
