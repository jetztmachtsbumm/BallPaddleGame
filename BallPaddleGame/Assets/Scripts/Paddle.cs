using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] private float movementSpeed;

    private void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + xMovement, -8, 8), transform.position.y, transform.position.z);
    }

}
