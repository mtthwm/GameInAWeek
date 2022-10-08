using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SceneTransitioner : MonoBehaviour
{
    private Animator m_transitioner;

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
        m_transitioner = GetComponent<Animator>();
    }

    public IEnumerator DoSceneTransition(int index, float transitionTime)
    {
        if (m_transitioner != null)
        {
            m_transitioner.SetTrigger("Start");
        }

        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
}
