using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnGameClear()
    {
        // 5秒後にクリアシーンに移行
        StartCoroutine(GameClearCoroutine());
    }

    private IEnumerator GameClearCoroutine()
    {
        yield return new WaitForSeconds(5f);  // 5秒待機

        // カーソルロック解除してCursorManagerを削除
        CursorManager.DestroyCursorManager();

        // クリアシーンに移行
        SceneManager.LoadScene("ClearScene");
    }
}
