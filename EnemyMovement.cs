using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Transform playerTransform;
    private Vector3 lastPosition; // 前フレームの位置を保存する変数
    private SpriteRenderer spriteRenderer; // SpriteRendererコンポーネント

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRendererコンポーネントの取得
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);

            // 敵のスプライトの反転処理
            if (transform.position.x < lastPosition.x)
            {
                // 左に移動している場合
                spriteRenderer.flipX = false; // SpriteをX軸で反転
            }
            else if (transform.position.x > lastPosition.x)
            {
                // 右に移動している場合
                spriteRenderer.flipX = true; // Spriteの反転を解除
            }

            lastPosition = transform.position; // 位置を更新
        }
    }
}
