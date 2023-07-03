using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuestionManager : MonoBehaviour
{
    public GameObject Panel;

    public Vector3[] positions;

    public Text Question;
    
    public Button Answer1Button;
    public Button Answer2Button;
    public Button Answer3Button;
    public Button Answer4Button;

    private int rnd;

    public List<QuestionAndAnswers> QnA;

    public void TrueAnswer(){
        // win
        Panel.SetActive(false);
        Debug.Log("win");
        FindObjectOfType<GameManager>().StartCoroutine("Firework");
        Invoke(nameof(NextLevel) , 2f);
    }

    public void FalseAnswer(){
        // lose
        Panel.SetActive(false);
        Debug.Log("lose");
        Invoke(nameof(Restart) , 0.5f);
    }

    private Vector3 tempPos;
    
    public void GenerateQuestion(){

        for (int i = 0; i < positions.Length; i++) {
            int rnd = Random.Range(0, positions.Length);
            tempPos = positions[rnd];
            positions[rnd] = positions[i];
            positions[i] = tempPos;
        }

        rnd = Random.Range(0 , QnA.Count);

        Question.text = QnA[rnd].Question;
        
        Answer1Button.image.sprite = QnA[rnd].Answers[0];
        Answer2Button.image.sprite = QnA[rnd].Answers[1];
        Answer3Button.image.sprite = QnA[rnd].Answers[2];
        Answer4Button.image.sprite = QnA[rnd].Answers[3];

        Answer1Button.transform.localPosition = positions[0];
        Answer2Button.transform.localPosition = positions[1];
        Answer3Button.transform.localPosition = positions[2];
        Answer4Button.transform.localPosition = positions[3];
    }

    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Start(){
        GenerateQuestion();
    }
}
