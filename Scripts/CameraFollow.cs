using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    private BallMovement ball;
    private counter count;
    private Rigidbody rb;
    public float moveSpeed;
    private bool isMoving = true;
    private Vector3 currentPosition;
    private bool isExecuted = false;
    
    
    void Start()
    {
        ball = FindObjectOfType<BallMovement>();
        count = FindObjectOfType<counter>();
        rb = GetComponent<Rigidbody>();
        currentPosition = transform.position;

    }
    void LateUpdate()
    {
        if(isExecuted == false)
        {
            if(Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);
                if(t.phase == TouchPhase.Began)
                {
                    if(isMoving == true)
                    {   
                        rb.AddForce(transform.up * moveSpeed);
                    }

                    if(isMoving == true)
                    {   
                        rb.AddForce(transform.forward * moveSpeed);
                    }
                    isExecuted = true;
                }
                

            }
        }
        

        if(transform.position.y > 10)
        {
            rb.velocity = new Vector3(0,0,rb.velocity.z);
        }

        if(transform.position.z > 7)
            {
                isMoving = false;
                rb.velocity = Vector3.zero;

                StartCoroutine(Reset(7f));
                
            }
        
    }

    private IEnumerator Reset(float Delay)
    {
        yield return new WaitForSeconds(Delay);

        count.executed = false;
        count.score = 10;
        count.Strike.SetActive(false);
        ball.executed = false;
        isExecuted = false;
        ball.pinText.SetActive(false);
        ball.score1.SetActive(false);
        ball.bgSound.volume = 2f;
        SceneManager.LoadScene(0);
    }
}
