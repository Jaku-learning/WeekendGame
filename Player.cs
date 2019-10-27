using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState { walking, idle }


public class Player : MonoBehaviour, IDamagable
{

    public GameObject deathScreen;

    public static Player instance { get; set; }

    [SerializeField] private float moveSpeed;
    [SerializeField] private int playerHealth = 10;
    public int playerDamage;
    private MovementState movementState;

    private Rigidbody2D playerRb;

    private void Awake()
    {
        instance = this;
        deathScreen.SetActive(false);
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        UpdateMovement();
        CheckHealth();
    }

    public int GetHealth()
    {
        return playerHealth;
    }

    private void UpdateMovement()
    {
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");

        if (xRaw < 0)
        {
            Move(Vector2.left);
            movementState = MovementState.walking;
        }
        else if (xRaw > 0)
        {
            Move(Vector2.right);
            movementState = MovementState.walking;
        }

        if (yRaw < 0)
        {
            Move(Vector2.down);
            movementState = MovementState.walking;
        }
        else if (yRaw > 0)
        {
            Move(Vector2.up);
            movementState = MovementState.walking;
        }

    }

    private void CheckHealth()
    {
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
            ShowDeathScreen();
        }
    }

    private void Move(Vector2 dir)
    {
        if (playerRb.velocity.sqrMagnitude < moveSpeed)
        {
            playerRb.AddForce(dir * moveSpeed * Time.deltaTime);
        }
        else if (playerRb.velocity.sqrMagnitude >= moveSpeed)
        {
            playerRb.AddForce(Vector2.zero * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            DoDamage(playerDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
    }

    public void DoDamage(int amount)
    {
        int enemyHealth = EnemyManager.instance.GetEnemyHealth();

        enemyHealth -= amount;

        if (enemyHealth <= 0)
        {
            Destroy(EnemyManager.instance.gameObject);
        }
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }
}
