﻿using UnityEngine;

public class Player : MonoBehaviour
{
    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    public Vector2 jumpForce = new Vector2(0, 300);
    
    // Update is called once per frame
    private void Update()
    {
        // Jump
        if (Input.GetKeyUp("space"))
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce);
        }
        
        // Die by being off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            this.Die();
        }
    }
    
    // Die by collision
    private void OnCollisionEnter2D(Collision2D other)
    {
        this.Die();
    }

    private void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
