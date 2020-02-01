using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPiece;
    private float initialPlayerSize = 2.56f;
    private float currentRightPiecePosition;
    private float currentLeftPiecePosition;

    private PlayerPiecesCollisionManager piecesCollisionManager;
    void Start()
    {
        piecesCollisionManager = GameObject.FindGameObjectWithTag("PlayerPiecesCollisionManager").GetComponent<PlayerPiecesCollisionManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            IncreaseUp();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            IncreaseRight();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            IncreaseLeft();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            piecesCollisionManager.AddPiece(collision.gameObject);
            Vector2 collisionPoint = collision.GetContact(0).point;
            //Debug.Log((int)(collisionPoint.x / initialPlayerSize));

            //float difX = collision.transform.position.x - transform.position.x;
            //float difY = collision.transform.position.y - transform.position.y;

            //if (difY > initialPlayerSize)
            //{
            //    //Debug.Log("Bateu em Cima!");
            //}
            //if (difX < -initialPlayerSize)
            //{
            //    IncreaseLeft();
            //}
            //if (difX > initialPlayerSize)
            //{
            //    IncreaseRight();
            //}

            //Destroy(collision.gameObject);
        }
    }

    private void IncreaseUp()
    {
        Vector3 piecePosition = transform.position + initialPlayerSize * Vector3.up;
        Instantiate(playerPiece, piecePosition, transform.rotation, transform);
    }

    private void IncreaseRight()
    {
        currentRightPiecePosition += initialPlayerSize;
        Vector3 piecePosition = transform.position + (currentRightPiecePosition * Vector3.right);
        Instantiate(playerPiece, piecePosition, transform.rotation, transform);
    }
    private void IncreaseLeft()
    {
        currentLeftPiecePosition += initialPlayerSize;
        Vector3 piecePosition = transform.position + (currentLeftPiecePosition * Vector3.left);
        Instantiate(playerPiece, piecePosition, transform.rotation, transform);
    }
}
