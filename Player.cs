using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshProを使用するための名前空間を追加するにゃ

public class Player : MonoBehaviour
{
    public int MentalPoint = 100;
    public Slider mentalBar; // UI Sliderを使用したMentalPointのヘルスバー作成するにゃ
    public Slider pointsSlider; // レベルアップまでのポイントを表示するスライダー
    public Transform projectilePrefab; // 弾のプレハブ
    public float shootingRate = 2.0f; // 発射レート
    private float shootCooldown; // 発射のクールダウン時間
    public int points = 0; // プレイヤーが持つポイント
    public int level = 1; // 現在のレベル
    public int pointsToNextLevel = 100; // 次のレベルアップに必要なポイント
    public float levelMultiplier = 1.5f; // レベルごとのポイント増加率
    public TextMeshProUGUI levelDisplay; // レベル表示用のTextMeshProUGUI
    public GameOverManager GameOverManager; // ゲームオーバー処理を行うスクリプトを参照するにゃ

    void Start()
    {
        if (mentalBar != null)
        {
            mentalBar.maxValue = MentalPoint;
            mentalBar.value = MentalPoint;
        }
        pointsSlider.maxValue = pointsToNextLevel; // スライダーの最大値を初期設定
        pointsSlider.value = points; // スライダーの現在値を初期設定
        shootCooldown = 0f;
        UpdateLevelDisplay(); // スタート時にレベル表示を更新
    }

    void Update()
    {
        if (MentalPoint <= 0)
        {
            Debug.Log("Player Defeated");
            if (GameOverManager != null)
            {
                GameOverManager.ShowGameOver();
            }
            else
            {
                Debug.LogError("GameOverManager not set!");
            }
        }

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        else
        {
            ShootNearestEnemy();
            shootCooldown = shootingRate;
        }

        CheckLevelUp(); // レベルアップをチェックだにゃ
    }

    void CheckLevelUp()
    {
        if (points >= pointsToNextLevel)
        {
            level++;
            points -= pointsToNextLevel;
            pointsToNextLevel = Mathf.CeilToInt(pointsToNextLevel * levelMultiplier);
            pointsSlider.maxValue = pointsToNextLevel; // スライダーの最大値を更新
            pointsSlider.value = points; // スライダーの現在値をリセット
            UpdateLevelDisplay(); // レベルアップ時にレベル表示を更新
            Debug.Log("Level Up! New level: " + level + ", Next level needs: " + pointsToNextLevel + " points.");
        }
    }

    public void TakeDamage(int damage)
    {
        MentalPoint -= damage;
        if (mentalBar != null)
        {
            mentalBar.value = MentalPoint;
        }
    }

    void ShootNearestEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();
        float closestDistance = float.MaxValue;
        Transform nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearestEnemy = enemy.transform;
            }
        }

        if (nearestEnemy != null)
        {
            Transform projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectile projectileScript = projectile.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.SetTarget(nearestEnemy);
            }
        }
    }

    public void AddPoints(int amount)
    {
        points += amount;
        pointsSlider.value = points; // スライダーの値を更新するにはこの行を追加
        Debug.Log("Points added: " + amount + ". Total points: " + points);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GakuChika"))
        {
            Collectible collectible = other.GetComponent<Collectible>();
            if (collectible != null)
            {
                AddPoints(collectible.value);
                Destroy(other.gameObject); // ガクチカを拾うと消去
            }
        }
    }

    // レベル表示を更新する関数
    void UpdateLevelDisplay()
    {
        levelDisplay.text = "Lv. " + level;
    }

}