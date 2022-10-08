using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] private float transitionTime;

    private SceneTransitioner m_sceneTransitioner;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    private void OnSceneLoaded(Scene aScene, LoadSceneMode aMode)

    {
        m_sceneTransitioner = FindObjectOfType<SceneTransitioner>();
    }

    public void Freeze()
    {
        Time.timeScale = 0;
    }

    public void Unfreeze()
    {
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Plays a transition and loads a specific scene index
    public void LevelAtIndex(int index)
    {
        StartCoroutine(m_sceneTransitioner.DoSceneTransition(index, transitionTime));
    }

    // Plays a transition and restarts the scene
    public void GameOver()
    {
        LevelAtIndex(SceneManager.GetActiveScene().buildIndex);
    }

    // Plays a transition and loads the next scene
    public void NextLevel()
    {
        LevelAtIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Plays a transition and loads the previous scene
    public void PreviousLevel()
    {
        LevelAtIndex(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
