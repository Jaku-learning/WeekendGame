using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour, IDamagable
{
    public static EnemyManager instance { get; private set; }
    [SerializeField] private EnemyCreator enemyData;

    private string enemyName;
    private int enemyHealth;
    private int enemyMinDamage;
    private int enemyMaxDamage;
    private int enemyChaseSpeed;

    private Rigidbody2D enemyRb;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();

        enemyName = enemyData.enemyName;
        enemyHealth = enemyData.enemyHealth;
        enemyMinDamage = enemyData.minDamage;
        enemyMaxDamage = enemyData.maxDamage;
        enemyChaseSpeed = enemyData.enemyChaseSpeed;
    }

    void Update()
    {
        EnemyFollow();
    }

    public int GetEnemyHealth()
    {
        return enemyHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            DoDamage(Random.Range(enemyMinDamage, enemyMaxDamage));
        }
    }

    public void DoDamage(int amount)
    {

        int playerHealth = Player.instance.GetHealth();

        playerHealth -= amount;

        if (playerHealth == 0)
        {
            Destroy(Player.instance.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyFollow()
    {
        Vector3 playerPos = Player.instance.transform.position;
        Vector2 move = Vector3.MoveTowards(transform.position, playerPos, enemyChaseSpeed * Time.deltaTime);
        enemyRb.MovePosition(move);
    }
}
