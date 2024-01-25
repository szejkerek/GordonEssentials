using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    public Action OnSceneChanged;
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneRoutine(sceneIndex));
    }

    IEnumerator LoadSceneRoutine(int sceneIndex)
    {
        FadeScreen fadeScreen = FadeScreen.Instance;
        if (fadeScreen == null)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
            Debug.LogError("Couldn't get screen fader in scene!");
        }
        else
        {
            fadeScreen.FadeOut();
            yield return new WaitForSeconds(fadeScreen.FadeDuration);

            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            operation.allowSceneActivation = false;

            float timer = 0f;
            while (timer <= fadeScreen.FadeDuration && !operation.isDone)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            OnSceneChanged?.Invoke();
            operation.allowSceneActivation = true;
            fadeScreen.FadeIn();
        }
    }
}
