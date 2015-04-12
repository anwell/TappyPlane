using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip ExplosionSound;

    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    public Vector2 jumpForce = new Vector2(0, 300);

    public bool GameOver = false;

    private AudioSource audioSource;
    private Rigidbody2D playerRigidbody;

    private void Start()
    {
        this.playerRigidbody = this.GetComponent<Rigidbody2D>();
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Jump
        if (!this.GameOver && Input.GetKeyUp("space"))
        {
            this.playerRigidbody.velocity = Vector2.zero;
            this.playerRigidbody.AddForce(jumpForce);
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
        this.audioSource.PlayOneShot(this.ExplosionSound, 1f);

        this.Die();
    }

    private void Die()
    {
        // We can die once time only.
        if (this.GameOver)
        {
            return;
        }

        this.GameOver = true;
        
        // Draw the Game over screen.
        Application.LoadLevelAdditive("GameOver");

        // Restart game in 3 seconds. 
        this.Invoke("RestartGame", 3f);
    }

    private void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
