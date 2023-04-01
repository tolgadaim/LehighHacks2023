using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    [SerializeField]
    private char answer;
    
    public void CheckAnswer()
    {
        bool correctAnswer;
        correctAnswer = transform.parent.GetComponent<QuestionScript>().CheckIfCorrectAnswer(answer);
        
        var imageColor = GetComponent<Image>().color;
        if (correctAnswer) {
            imageColor = new Color(0f, 1f, 0f);
            GetComponent<Image>().color = imageColor;
        }
        else {
            imageColor = new Color(1f, 0f, 0f);
            GetComponent<Image>().color = imageColor;
        }

        foreach (Button button in transform.parent.GetComponentsInChildren<Button>())
        {   
            button.enabled = false;
        }
        
    }

}
