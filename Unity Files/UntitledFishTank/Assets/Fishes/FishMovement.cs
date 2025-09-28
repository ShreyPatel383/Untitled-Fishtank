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
        //Flip the fish when it changes direction.
        if (xMult < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (xMult > 0) { 
            GetComponent <SpriteRenderer>().flipX = false;
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
        //change direction every 5 seconds.
        running = true;
        yield return new WaitForSeconds(5);
        xMult = Random.Range(-1f, 1f);
        yMult = Random.Range(-1f, 1f);
        running = false;
    }
}
