using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour // クラス名をスクリプトファイル名に一致させるにゃ
{
    private string sceneName;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}
