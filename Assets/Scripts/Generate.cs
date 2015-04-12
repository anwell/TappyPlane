using UnityEngine;

public class Generate : MonoBehaviour
{
    public GameObject rocks;

    [UnityEngine.SerializeField]
    private GameObject getReadyGameObject;

    [UnityEngine.SerializeField]
    private GUIStyle scoreGuiStyle;

    [UnityEngine.SerializeField]
    private Player player;

    private int score = 0;
    
    // Use this for initialization
    private void Start()
    {
        // Delete the "Get Ready" panel in 3 seconds. 
        this.Invoke("CleanStartingUI", 3f);

        InvokeRepeating("CreateObstacle", 1f, 1.5f);
    }

    private void Update()
    {
        if (this.player.GameOver)
        {
            this.CleanStartingUI();
        }
    }
    
    // Update is called once per frame
    private void OnGUI() 
    {
        GUILayout.Label(" Score: " + score.ToString(), this.scoreGuiStyle);
    }

    private void CreateObstacle()
    {
        Instantiate(rocks);
        this.score++;
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