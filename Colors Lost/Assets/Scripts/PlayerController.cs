using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int collectedBalls = 0;  //集めたボールの数

    // GameControllerスクリプトの参照をInspectorで設定
    public GameController gameController;


    //トリガーエリアに入った時の処理
    private void OnTriggerEnter(Collider other)
    {
        //タグが"Ball"の場合のみ処理を行う
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Press F to collect the ball.");
            StartCoroutine(WaitForCollection(other.gameObject));
        }
    }

    private IEnumerator WaitForCollection(GameObject ball)
    {
        // "F"キーが押されるまで待機
        while (!Input.GetKeyDown(KeyCode.F))
        {
            yield return null;
        }

        // ボールを取得、破壊して数を増やす
        CollectBall(ball);
    }

    private void CollectBall(GameObject ball)
    {
        Destroy(ball);  // ボールを破壊
        collectedBalls++;  // 所持数を増やす

        Debug.Log("Collected Ball: " + collectedBalls);

        // 全てのボールを集めたかをチェック
        if (collectedBalls >= 7)
        {
            gameController.OnGameClear();  // ゲームクリアの処理を実行
            Debug.Log("All balls collected! The map is now colorful!");
        }
    }
}
