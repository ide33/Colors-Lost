using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // プレイヤーの移動速度を設定する変数
    public CharacterController controller;  // CharacterControllerコンポーネントへの参照

    void Start()
    {
        // CharacterControllerコンポーネントを取得
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // プレイヤーの移動入力を取得（WASDや矢印キー）
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // プレイヤーの移動方向を計算
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // 移動を実行（移動方向に移動速度を掛け、Time.deltaTimeで時間補正）
        controller.Move(move * speed * Time.deltaTime);
    }
}
