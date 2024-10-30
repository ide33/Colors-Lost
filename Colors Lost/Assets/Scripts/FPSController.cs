using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    float x, z;
    float speed = 0.2f;  //移動速度

    public GameObject cam;  //プレイヤー視点のカメラを設定
    Quaternion cameraRot, characterRot;  //カメラとキャラクターの回転管理の変数
    float Xsensityvity = 2.5f, Ysensityvity = 2.5f;  //マウス感度
    float minX = -90f, maxX = 90f;  //カメラの垂直回転角度の制限

    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    void Update()
    {
        //マウスの移動量を取得、視点移動量を計算
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;


        
        //それぞれの回転を反映
        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);

        
        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;  //カメラの回転を設定
        transform.localRotation = characterRot;  //プレイヤーの回転を設定
    }

    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;  //水平方向の移動量を設定
        z = Input.GetAxisRaw("Vertical") * speed;  //前後方向の異動量を設定


        // カメラのforwardベクトルのY成分をゼロにして、正規化することで地面に沿った移動に限定
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = cam.transform.right;
        right.y = 0;
        right = right.normalized;


        // 修正されたforwardとrightを使って移動
        transform.position += forward * z + right * x;
    }

    public Quaternion ClampRotation(Quaternion q)  //垂直回転の角度を制限
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
}
