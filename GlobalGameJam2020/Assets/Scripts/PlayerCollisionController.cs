using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private PlayerPiecesCollisionManager piecesCollisionManager;
    void Start()
    {
        piecesCollisionManager = GameObject.FindGameObjectWithTag("PlayerPiecesCollisionManager").GetComponent<PlayerPiecesCollisionManager>();
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

    
}
