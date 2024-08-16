using UnityEngine;

public class HealthBarFollowPlayer : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public Vector3 offset;   // プレイヤーからのオフセット

    void Update()
    {
        if (player != null)
        {
            // プレイヤーの位置にオフセットを加えて、その位置にスライダーを設定
            transform.position = player.position + offset;
        }
    }
}