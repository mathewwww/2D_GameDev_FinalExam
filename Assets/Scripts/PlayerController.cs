using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] Rigidbody2D rg;
    public float speed = 10f;

    private Rigidbody2D rb;

    void Update()
    {
        MoveGameObject();
    }

    private void MoveGameObject()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rg.transform.Translate(Vector2.right * horizontalInput * Time.deltaTime * speed);
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
             rg.transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);
        }
    }


}
