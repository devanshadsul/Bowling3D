using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float minYRotation = -6f;
    public float maxYRotation = 6f;
    public float currentrotationY;
    public float currentYRotation;

    private bool rotationActive = true;

    private void Update()
    {
        if (rotationActive)
        {
            // Calculate the current y-axis rotation using Mathf.PingPong
            currentYRotation = Mathf.PingPong(Time.time * rotationSpeed, maxYRotation - minYRotation) + minYRotation;

            // Create the target rotation quaternion based on the current y-axis rotation
            Quaternion targetRotation = Quaternion.Euler(0f, currentYRotation, 0f);

            // Apply the rotation to the game object's transform
            transform.rotation = targetRotation;
        }

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began)
            {
                rotationActive = !rotationActive;
                currentrotationY = currentYRotation;
            }
            
        }
    }
}
