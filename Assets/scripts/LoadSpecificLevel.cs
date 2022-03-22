using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificLevel : MonoBehaviour
{
    public Animator fadeIn;

    public static LoadSpecificLevel instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of LoadSpecificLevel");
            return;
        }

        instance = this;
    }

    public void LoadLevel(string LevelName)
    {
        StartCoroutine(LoadXlevel(LevelName));
    }

    public IEnumerator LoadXlevel(string name)
    {
        fadeIn.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }
}
