using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //プレイヤーのTransforrmを参照するにゃ

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);//プレイヤーの位置情報に追従するにゃ！
        }
    }
}