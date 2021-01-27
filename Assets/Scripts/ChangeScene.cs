using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    int scene;

    [SerializeField]
    public float transitionTime = 1f;

    public Animator transition;

    public void ChangeToSelectedScene(int scene)
    {
        //SceneManager.LoadScene(scene);
        StartCoroutine(LoadLevel(scene));
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play Animation
        transition.SetTrigger("Start");

        // Wait
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
