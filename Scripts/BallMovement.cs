using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public Arrow rotation;
    public Vector3 startPosition;
    public GameObject PlayTap;
    public AudioSource rollingSound;
    public AudioSource StrikeSound;
    public bool executed = false;
    public GameObject pinText;
    public GameObject score1;
    public AudioSource bgSound;

    void Start()
    {
        pinText.SetActive(false);
        score1.SetActive(false);
        PlayTap.SetActive(true);
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rotation = FindObjectOfType<Arrow>();
    }

    
    void Update()
    {   
        if(executed == false)
        {
            if(Input.touchCount > 0)
            {   Touch t = Input.GetTouch(0);
                if(t.phase == TouchPhase.Began)
                {
                    StartCoroutine(rotationDelay(0.1f));
                    executed = true;
                }
            }
        }
        

        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     StartCoroutine(rotationDelay(0.1f));
        // }


        
    }

    private IEnumerator rotationDelay(float Delay)
    {
        yield return new WaitForSeconds(Delay);
        PlayTap.SetActive(false); 
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.currentrotationY, transform.rotation.eulerAngles.z);
        rb.AddForce(transform.forward * speed);
        rollingSound.Play();
        bgSound.volume = 0.1f;
    }

    void OnCollisionEnter(Collision collide)
    {
        if(collide.gameObject.CompareTag("triggerPins"))
        {
            StrikeSound.Play();
            rollingSound.Stop();
            pinText.SetActive(true);
            score1.SetActive(true);
        }
    }
}
