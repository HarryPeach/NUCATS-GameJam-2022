using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 0.05f;
    private void Start()
    {
        Debug.Log("Started!");
    }
    private void FixedUpdate()
    {
        Rigidbody2D rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.MovePosition(this.transform.position + new Vector3(movementSpeed, 0, 0));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{other.name} collided with me! Bye!");
        Destroy(gameObject);
    }
}
