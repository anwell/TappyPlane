using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Vector2 velocity = new Vector2(-4, 0);
    public float range = 4;
    
    // Use this for initialization
    private void Start()
    {
        rigidbody2D.velocity = velocity;
        this.transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z);
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