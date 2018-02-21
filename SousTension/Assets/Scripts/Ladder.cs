using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float speed = 2;


    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if (Input.GetAxis("Vertical") > 0)  //Going up the ladder
            {
                //Debug.Log("FUUUUUUUU en haut");
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed = 1;

            }
            else if (Input.GetAxis("Vertical") < 0) //Going down the ladder
            {
                //Debug.Log("FUUUUUUUU en bas");
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed = 1;

            }
            else
            {
                
                col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);   //Lowering gravity impact while idle on the ladder
                

            }
        }
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Ladder", false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().speed = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Ladder", true);
        
    }




}
