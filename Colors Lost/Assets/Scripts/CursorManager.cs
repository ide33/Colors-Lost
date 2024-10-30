using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static bool cursorLock = true;  //カーソルロック状態を共有
    private static CursorManager instance;  //シングルトンインスタンス

    void Awake()
    {
        // シングルトンの設定
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  //シーンが変わってもオブジェクトを保持
        }
        else
        {
            Destroy(gameObject);  // 既に存在する場合は重複しないように削除
        }
    }

    void Update()
    {
        UpdateCursorLock();
    }

    private void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  // Escapeキーでロック解除
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))  // 左クリックでロック
        {
            cursorLock = true;
        }

        if (cursorLock)  // trueのときカーソルをロック
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else  // falseのときロック解除
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // カーソルロックを解除してCursorManagerオブジェクトを破壊するメソッド
    public static void DestroyCursorManager()
    {
        if (instance != null)
        {
            cursorLock = false;  // カーソルロック解除
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(instance.gameObject);  // CursorManagerオブジェクトを破壊
        }
    }
}
