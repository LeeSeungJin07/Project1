using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private CanvasGroup _sceneLoaderCanvasGroup = null;
    private string _loadSceneName = string.Empty;

    private void Awake()
    {
        _sceneLoaderCanvasGroup = GetComponentInChildren<CanvasGroup>();
        _sceneLoaderCanvasGroup.alpha = 0;
        _sceneLoaderCanvasGroup.gameObject.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        _sceneLoaderCanvasGroup.gameObject.SetActive(true);
        SceneManager.sceneLoaded += LoadSceneEnd;
        _loadSceneName = sceneName;

        Managers.Clear();
        StartCoroutine(Load(sceneName));
    }

    private IEnumerator Load(string sceneName)
    {
        yield return StartCoroutine(Fade(true));

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress >= 0.9f)
            {
                op.allowSceneActivation = true;
                yield break;
            }
        }
    }

    private void LoadSceneEnd(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == _loadSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= LoadSceneEnd;
        }
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;
        _sceneLoaderCanvasGroup.alpha = isFadeIn ? 0 : 1;

        while (timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 2f;
            _sceneLoaderCanvasGroup.alpha = Mathf.Lerp(isFadeIn ? 0 : 1, isFadeIn ? 1 : 0, timer);
        }

        if (!isFadeIn)
            _sceneLoaderCanvasGroup.gameObject.SetActive(false);
    }
}
