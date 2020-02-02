using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Channel3;

public class LevelLoaderManager : Singleton<LevelLoaderManager>
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();   
    }

    public void ReloadCurrentLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(LoadLevel(sceneIndex + 1));
        }
        else
        {
            StartCoroutine(LoadLevel(0));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(levelIndex);
    }
}
