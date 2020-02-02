using UnityEngine;
using Channel3;
using TMPro;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private SceneConfigurationScriptableObject sceneConfiguration;

    [SerializeField]
    private TextMeshProUGUI gameHudMessage;

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
            Debug.Log("Pass: player is in one piece");
            gameHudMessage.text = "";
            isGameOver = true;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
