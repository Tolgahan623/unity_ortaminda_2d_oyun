using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotatingSpeed;

    public GameObject coinFxPrefab;


    void Update()
    {
        transform.Rotate(0f , rotatingSpeed * Time.deltaTime , 0f);    
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("player")){
            Destroy(gameObject);
            GameObject go = Instantiate(coinFxPrefab , transform.position , transform.rotation);
            Destroy(go , 3f);
        }
    }
}
