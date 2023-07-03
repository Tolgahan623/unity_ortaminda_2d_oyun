using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    public float rotatingSpeed;
    public float timer;
    private float tempTimer;

    void Start(){
        tempTimer = timer;
    }

    void Update()
    {
        tempTimer -= Time.deltaTime;
        if(tempTimer <= 0){
            flip();
        }
        transform.Rotate(0f , 0f , rotatingSpeed * Time.deltaTime);
    }

    void flip(){
        rotatingSpeed *= -1f;
        tempTimer = timer;
    }
}
