using UnityEngine;
using Channel3;
using TMPro;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private SceneConfigurationScriptableObject sceneConfiguration;

    [SerializeField]
    private TextMeshProUGUI gameHudMessage;

    [SerializeField]
    private LevelLoaderManager levelManager;

    private bool isGameOver = false;
    
    private int piecesLeft;

    // Start is called before the first frame update
    void Start()
    {
        piecesLeft = sceneConfiguration.NumberOfPieces;
        gameHudMessage.text = sceneConfiguration.GameMessage;
    }

    public void DecrementPieceLeft()
    {
        piecesLeft--;

        if(piecesLeft <= 1)
        {
            gameHudMessage.text = "";
            isGameOver = true;

            levelManager.StartLevelTransition();
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
