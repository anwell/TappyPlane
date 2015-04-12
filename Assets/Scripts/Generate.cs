using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject rocks;

    [UnityEngine.SerializeField]
    private GUIStyle scoreGuiStyle;

    private int score = 0;
    
    // Use this for initialization
    private void Start()
    {
        InvokeRepeating("CreateObstacle", 1f, 1.5f);
    }
    
    // Update is called once per frame
    private void OnGUI() 
    {
        GUI.color = Color.black;
        GUILayout.Label(" Score: " + score.ToString(), this.scoreGuiStyle);
    }

    private void CreateObstacle()
    {
        Instantiate(rocks);
        score++;
    }
}