using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 velocity = new Vector2(-4, 0);
    public float range = 4f;
    
    // Use this for initialization
    private void Start()
    {
        rigidbody2D.velocity = velocity;

        float y = Random.Range(transform.position.y - this.range, transform.position.y);
        this.transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void Update()
    {
        // Test if the obstacle is out of the screen.
        if (this.transform.position.x <= -30f)
        {
            // Suicide.
            DestroyObject(this.gameObject);
        }
    }
}