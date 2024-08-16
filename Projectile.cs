using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;

    private Transform target;

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);  // ターゲットがない場合は弾を消去
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 弾が敵に当たったかどうかを確認するより一般的な条件に変更
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);  // 弾が何かに当たったら消滅
        }
    }
}
