using UnityEngine;
using Channel3;
using TMPro;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private SceneConfigurationScriptableObject sceneConfiguration = default;

    [SerializeField]
    private TextMeshProUGUI gameHudMessage = default;

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

            LevelLoaderManager.Instance.LoadNextLevel();
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
