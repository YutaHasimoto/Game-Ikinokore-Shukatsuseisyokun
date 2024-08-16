using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;  // 移動速度
    private Vector3 startMousePosition;  // マウス開始位置
    private Vector2 currentSwipe;
    private SpriteRenderer spriteRenderer; // スプライトレンダラーを追加

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // スプライトレンダラーを取得にゃ
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // マウスボタンが押されたときにゃ
        {
            startMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))  // マウスボタンが押されている間にゃ
        {
            currentSwipe = (Vector2)Input.mousePosition - (Vector2)startMousePosition;
            rb.velocity = currentSwipe.normalized * speed;  // マウスの動きに基づいて速度を設定にゃ

            // スプライトの向きを変えるにゃ規模
            spriteRenderer.flipX = currentSwipe.x < 0;
        }
        else if (Input.GetMouseButtonUp(0))  // マウスボタンが離されたときにゃ
        {
            currentSwipe = (Vector2)Input.mousePosition - (Vector2)startMousePosition;
            rb.velocity = currentSwipe.normalized * speed;
            spriteRenderer.flipX = currentSwipe.x < 0;
        }
        else
        {
            rb.velocity = Vector2.zero;  // マウスが動いていない時は動かないにゃ
        }
    }
}