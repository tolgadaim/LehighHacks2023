using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class QuestionBG : MonoBehaviour
{
    void Update()
    {
        if (FindObjectOfType<QuestionScript>() != null)
        {
            GetComponent<Image>().enabled = true;
        }
        else {
            GetComponent<Image>().enabled = false;
        }
    }
}
