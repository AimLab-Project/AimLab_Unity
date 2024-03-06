using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using System;

public class WebGLSceneManager : Singleton<WebGLSceneManager>
{
    private Slider m_ProgressBar;

    private string m_NextScene;

    public async UniTask LoadScene(string sceneName)
    {
        SceneManager.LoadScene("LoadingScene");
        m_NextScene = sceneName;
        await LoadSceneAsync();
    }

    public async UniTask LoadSceneCallback(string sceneName, Action doComplete)
    {
        SceneManager.LoadScene("LoadingScene");
        m_NextScene = sceneName;
        await LoadSceneAsync();
    }

    private async UniTask LoadSceneAsync()
    {
        await UniTask.Yield();
        AsyncOperation op = SceneManager.LoadSceneAsync(m_NextScene);
        op.allowSceneActivation = false;
        m_ProgressBar = FindObjectOfType<Slider>();
        float timer = 0.0f;
        while (!op.isDone)
        {
            await UniTask.Yield();
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                m_ProgressBar.value = Mathf.Lerp(m_ProgressBar.value, op.progress, timer);
                if (m_ProgressBar.value >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                m_ProgressBar.value = Mathf.Lerp(m_ProgressBar.value, 1f, timer);
                if (m_ProgressBar.value == 1.0f)
                {
                    op.allowSceneActivation = true;
                    return;
                }
            }
        }
        SceneManager.LoadScene(m_NextScene);
    }

    private async UniTask LoadSceneAsyncCallBack(Action doComplete)
    {
        await UniTask.Yield();
        AsyncOperation op = SceneManager.LoadSceneAsync(m_NextScene);
        op.allowSceneActivation = false;
        m_ProgressBar = FindObjectOfType<Slider>();
        float timer = 0.0f;
        while (!op.isDone)
        {
            await UniTask.Yield();
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                m_ProgressBar.value = Mathf.Lerp(m_ProgressBar.value, op.progress, timer);
                if (m_ProgressBar.value >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                m_ProgressBar.value = Mathf.Lerp(m_ProgressBar.value, 1f, timer);
                if (m_ProgressBar.value == 1.0f)
                {
                    op.allowSceneActivation = true;
                    return;
                }
            }
        }
        SceneManager.LoadScene(m_NextScene);

        doComplete.Invoke();

    }
}
