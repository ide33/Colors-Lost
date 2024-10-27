using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform playerBody;  // プレイヤーの体に対応するTransform（Y軸の回転に使用）
    public float mouseSensitivity = 100f;  // マウスの感度を調整するための変数
    private float xRotation = 0f;  // カメラの上下の回転角度を追跡する変数

    void Start()
    {
        // マウスカーソルを非表示にしてゲーム画面の中央に固定
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // マウスの移動量を取得し、感度を掛け算して速度を調整
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 上下の視点移動制限：X軸の回転角度を更新して制限を設定
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // 90度以上上下に視点が移動しないように

        // カメラの上下回転（プレイヤーに子オブジェクトとして付けているカメラのRotationを直接変更）
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // プレイヤーのY軸方向の回転を更新（プレイヤーが横方向に回転）
        playerBody.Rotate(Vector3.up * mouseX);
    }

}
