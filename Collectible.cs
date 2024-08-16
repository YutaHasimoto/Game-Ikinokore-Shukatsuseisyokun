using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 10;  // ガクチカの価値

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // プレイヤーがガクチカを獲得
            other.GetComponent<Player>().AddPoints(value);
            Destroy(gameObject);  // ガクチカを破壊して消去
        }
    }
}