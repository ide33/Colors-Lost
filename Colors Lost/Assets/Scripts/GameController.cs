using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Camera mainCamera; // メインカメラをInspectorで割り当て
    private float initialFogDensity; // 初期Fog Density
    private Color initialBackgroundColor; // 初期の背景色

    void Start()
    {
        // 初期Fog Densityと背景色を保存
        initialFogDensity = RenderSettings.fogDensity;
        initialBackgroundColor = mainCamera.backgroundColor;

        // ゲーム開始時の設定
        RenderSettings.fogDensity = 0.5f; // Fogの密度を0.5に設定
        mainCamera.backgroundColor = Color.gray; // カメラの背景色をグレーに設定
    }

    // 全てのボールを集めた際に呼ばれる関数
    public void OnGameClear()
    {
        // Fog Densityを0に設定
        RenderSettings.fogDensity = 0f;

        // カメラの背景色を元に戻す
        mainCamera.backgroundColor = initialBackgroundColor;

        Debug.Log("Game Clear! Map color has been restored.");

        // 5秒後にゲームクリアシーンに移動するコルーチンを開始
        StartCoroutine(LoadClearSceneAfterDelay(5f));
    }

    private IEnumerator LoadClearSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 指定された秒数待機
        SceneManager.LoadScene("ClearScene"); // ゲームクリアシーンに移動
    }
}
