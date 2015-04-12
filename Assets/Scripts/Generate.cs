using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject rocks;
    int score = 0;
    
    // Use this for initialization
    private void Start()
    {
        InvokeRepeating("CreateObstacle", 1f, 1.5f);
    }
    
    // Update is called once per frame
    private void OnGUI() 
    {
        GUI.color = Color.black;
        GUILayout.Label(" Score: " + score.ToString());
    }

    private void CreateObstacle()
    {
        Instantiate(rocks);
        score++;
    }
}