using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Channel3;

public class StageManager : Singleton<StageManager>
{
    [SerializeField]
    private SceneConfigurationScriptableObject sceneConfiguration;

    private bool isGameOver = false;


    private int piecesLeft;

    // Start is called before the first frame update
    void Start()
    {
        piecesLeft = sceneConfiguration.NumberOfPieces;
    }

    public void DecrementPieceLeft()
    {
        piecesLeft--;

        if(piecesLeft <= 1)
        {
            Debug.Log("Pass: player is in one piece");
            isGameOver = true;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
