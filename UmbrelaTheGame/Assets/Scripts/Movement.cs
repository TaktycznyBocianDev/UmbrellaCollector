using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("How fast will player be")]
    [SerializeField] float speed;
    [Header("Movement bound")]
    [SerializeField] float movementClapping;


    private void Update()
    {
        Move();
        MoveBound();

    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed;
        }
    }
    private void MoveBound()
    {
        if (transform.position.x >= movementClapping)
        {
            transform.position = new Vector3(movementClapping, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -movementClapping)
        {
            transform.position = new Vector3(- movementClapping, transform.position.y, transform.position.z);
        }
    }

}
