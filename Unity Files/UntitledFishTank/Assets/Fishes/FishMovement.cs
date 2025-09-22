using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FishMovement: MonoBehaviour
{
    public float speed;
    bool running = false;
    public float xMult;
    public float yMult;

    void Start() 
    {


    }

    void Update() 
    {
        if (!running) {
            StartCoroutine(ChangeDirection());
        }
        Move();
        
    }

    void Move() 
    {
        transform.position += transform.right * (Time.deltaTime * speed * xMult);
        transform.position += transform.up * (Time.deltaTime * speed * yMult);
    }
    
    IEnumerator ChangeDirection() 
    {
        running = true;
        yield return new WaitForSeconds(3);
        xMult = Random.Range(-1f, 1f);
        yMult = Random.Range(-1f, 1f);
        running = false;
    }
}
