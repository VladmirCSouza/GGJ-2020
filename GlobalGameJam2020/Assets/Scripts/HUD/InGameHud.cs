using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameHud : MonoBehaviour
{
    public void ResetGame()
    {
        LevelLoaderManager.Instance.ReloadCurrentLevel();
    }
}
