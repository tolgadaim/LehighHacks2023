using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int movementLength = 1;
    [SerializeField]
    private int maxHunger = 15;
    [SerializeField]
    private Image hungerBar;
    [SerializeField]
    private Transform deathMenu;
    [SerializeField]
    private Transform questions;
    [SerializeField]
    private bool useHunger;

    private float hunger;
    public bool RestrictMovement;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Water")
        {
            Death();
        }

        if (other.gameObject.tag == "Food")
        {
            ActivateQuestion();
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        hunger = maxHunger;
    }

    void Update()
    {
        if (GameObject.FindObjectOfType<TimeManager>().CheckPaused() == true)
            return;
            
        if (hungerBar != null)
        {
            hungerBar.fillAmount = Mathf.Max(0, hunger / maxHunger);
        }

        if (hunger <= 0)
        {
            Death();
        }

        if (RestrictMovement != true)
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
        
        if (useHunger)
            hunger -= Time.deltaTime;
    }

    void ActivateQuestion()
    {
        GameObject[] children = new GameObject[questions.childCount];
        for (int i = 0; i < questions.childCount; i++)
        {
            children[i] = questions.GetChild(i).gameObject;
        }
        
        int randomIndex = Random.Range(0, children.Length);
        children[randomIndex].SetActive(true);
        GameObject.FindObjectOfType<TimeManager>().PauseTime();
    }

    public void EatFish()
    {
        hunger = Mathf.Min(hunger + 10.0f, maxHunger);
    }

    void Death()
    {
        GameObject.FindObjectOfType<TimeManager>().PauseTime();
        Invoke("DeathHelper", 1f);
    }

    void DeathHelper()
    {
        deathMenu.gameObject.SetActive(true);
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
        RestrictMovement = true;
    }

    void Fall()
    {
        transform.localPosition += new Vector3(0, -0.5f, 0);
        if (GameObject.FindObjectOfType<TimeManager>().CheckPaused() == false)
            RestrictMovement = false;
    }
}
