using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public int coinAmount;

    public bool canDie;
    public bool canMove;

    public GameObject QuestionPanel;

    private bool isQuestion;




    void Start(){
        isQuestion = FindObjectOfType<GameManager>().isQuestion;
    }


    void Update(){
        // LEVEL GEÇME
        if(Input.GetKey(KeyCode.Space)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            canDie = !canDie;
        }
    }


    public GameObject deathFxPrefab;
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("saw") || col.gameObject.CompareTag("fireTrap") ||
        col.gameObject.CompareTag("spikes")){
            if(!canDie) return;
            this.gameObject.SetActive(false);
            GameObject go = Instantiate(deathFxPrefab , transform.position , transform.rotation);
            Destroy (go , 5f);
            Invoke(nameof(restart) , 3f);
        }

        if(col.gameObject.CompareTag("levelEnd")){
            if(!isQuestion){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            else{
            QuestionPanel.SetActive(true);
            FindObjectOfType<QuestionManager>().GenerateQuestion();
            GetComponent<playerMovement>().canMove = false;
            }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(col.gameObject.CompareTag("coin")){
            coinAmount++;
            FindObjectOfType<GameManager>().goldAmount--;
            int x = FindObjectOfType<GameManager>().goldAmount;
            if(x <= 0){
                isQuestion = false;
            }
        }
    }

    void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
