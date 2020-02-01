using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPiecesCollisionManager : MonoBehaviour
{
    private List<GameObject> pieces;
    // Start is called before the first frame update
    void Start()
    {
        pieces = new List<GameObject>();
    }

    private void LateUpdate()
    {
        if (pieces.Count > 1)
        {
            Destroy(pieces[0]);
            pieces.Clear();
        }
    }

    public void AddPiece(GameObject piece)
    {
        Debug.Log(piece.name);
        pieces.Add(piece);
    }
}
