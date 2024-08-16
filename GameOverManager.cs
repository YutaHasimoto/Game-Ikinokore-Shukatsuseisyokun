using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen; // ゲームオーバー画面を参照するためのGameObject

    // ゲームオーバー処理を行う
    public void ShowGameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // ゲームオーバー画面を表示
            Time.timeScale = 0; // ゲームの時間を停止
        }
        else
        {
            Debug.LogError("GameOver screen not set!");
        }
    }
}
