using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;
    public int health = 20;
    public GameObject gakuChikaPrefab;  // ガクチカのプレハブ参照にゃ

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DropGakuChika();  // ガクチカをドロップする関数を呼び出すのにゃ
            Destroy(gameObject);  // 敵を消滅させるにゃ
        }
    }

    void DropGakuChika()
    {
        // 敵の現在位置にガクチカポイントを生成にゃ
        Instantiate(gakuChikaPrefab, transform.position, Quaternion.identity);
    }
}