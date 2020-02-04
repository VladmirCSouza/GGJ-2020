using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PiecesCollisionManager.Instance.AddPiece(collision.gameObject);
            Vector2 collisionPoint = collision.GetContact(0).point;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Lava"))
        {
            LevelLoaderManager.Instance.ReloadCurrentLevel();
            StageManager.Instance.SetGameOver();
        }
    }

}
