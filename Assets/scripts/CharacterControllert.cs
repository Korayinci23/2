using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public Camera cam;


    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

    }
}



