using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class counter : MonoBehaviour
{
    public GameObject Strike;
    public Transform[] pins;
    public Transform ball;
    public bool executed = false;
    //private float pinPos = -2.95f;
    public TMP_Text scoreText;

    public int score = 10;

    void Update()
    {
        
        if (ball.position.z > 0f)
        {
            StartCoroutine(CheckPinsAfterDelay(6f));
            

        }
    }

    private IEnumerator CheckPinsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (executed == false)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                if(pins[i].position.y == 0.3499999f)
                {
                    
                }
                else
                {
                    score--;
                }
               
            }

            if(score == 0)
            {
                Strike.SetActive(true);
            }
            
             Debug.Log(score);
             this.scoreText.text = score.ToString();
             executed = true;
        }
    }
}
