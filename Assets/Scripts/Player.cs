using UnityEngine;

public class Player : MonoBehaviour
{
    // The force which is added when the player jumps
    // This can be changed in the Inspector window
    public Vector2 jumpForce = new Vector2(0, 300);

    [UnityEngine.SerializeField]
    private GameObject getReadyGameObject;

    private bool gameOver = false;

    private void Start()
    {
        // Delete the "Get Ready" panel in 3 seconds. 
        this.Invoke("CleanStartingUI", 3f);
    }
    
    // Update is called once per frame
    private void Update()
    {
        // Jump
        if (!this.gameOver && Input.GetKeyUp("space"))
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
        // We can die once time only.
        if (this.gameOver)
        {
            return;
        }

        this.gameOver = true;

        this.CleanStartingUI();

        // Draw the Game over screen.
        Application.LoadLevelAdditive("GameOver");

        // Restart game in 3 seconds. 
        this.Invoke("RestartGame", 3f);
    }

    private void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    private void CleanStartingUI()
    {
        if (this.getReadyGameObject != null)
        {
            DestroyObject(this.getReadyGameObject);
            this.getReadyGameObject = null;
        }
    }
}
