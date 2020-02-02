using System.Collections.Generic;
using UnityEngine;
using Channel3;

public class PiecesCollisionManager : Singleton<PiecesCollisionManager>
{
    [SerializeField]
    private GameObject playerPiece;
    private float initialPlayerSize = 2.56f;
    private float currentRightPiecePosition;
    private float currentLeftPiecePosition;

    private List<GameObject> pieces;

    void Start()
    {
        pieces = new List<GameObject>();
    }

    private void LateUpdate()
    {
        if (pieces.Count > 1)
        {
            while(pieces[0].transform.childCount > 0)
            {
                pieces[0].transform.GetChild(0).SetParent(pieces[1].transform);
            }

            Destroy(pieces[0]);
            pieces.Clear();
        }
    }

    public void AddPiece(GameObject piece)
    {
        pieces.Add(piece);
    }
}
