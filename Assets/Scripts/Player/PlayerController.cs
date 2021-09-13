using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashForse;
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool dashIsReady;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float maxPlayerSpeed;
    [SerializeField] private int maxPlayerJumps;
    [SerializeField] private int currentPlayerJumps;

    private Rigidbody2D playerRb;
    private Health playerHealth;
    private SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
        dashIsReady = true;
        currentPlayerJumps = maxPlayerJumps;
        playerRb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    { 
        FlipPlayerSpriteOnInput();

        LimitPlayerSpeed();

        MovePlayer();
        Jump();
        Dash();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        playerRb.AddForce(Vector3.right * horizontalInput * speed);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (isOnGround || currentPlayerJumps > 0))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            currentPlayerJumps--;
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashIsReady)
        {
            if(playerSprite.flipX)
            {
                playerRb.AddForce(Vector2.left * dashForse, ForceMode2D.Impulse);
                //playerRb.velocity = Vector2.left * dashForse;
            }
            else
            {
                playerRb.AddForce(Vector2.right * dashForse, ForceMode2D.Impulse);
                //playerRb.velocity = Vector2.right * dashForse;
            }
            dashIsReady = false;
            StartCoroutine(DashCooldown());
        }
    }

    void FlipPlayerSpriteOnInput()
    {
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            playerSprite.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < 0.0f)
        {
            playerSprite.flipX = true;
        }
    }

    void LimitPlayerSpeed()
    {
        if (playerRb.velocity.magnitude > maxPlayerSpeed)
        {
            playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxPlayerSpeed);
        }
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        dashIsReady = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
            currentPlayerJumps = maxPlayerJumps;
        }


        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Вызываем метод GetDamage() компонента Health
            //Отталкиваем игрока в противоположную сторону
            //Запускаем таймер на временную неуязвимость (0.3 - 0.5 секунды)
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient"))
        {
            //Добавляем в инвентарь игрока полученный ингредиент
            Debug.Log("Trigger: " + collision.name);
            Destroy(collision.gameObject);
            
        }

        if(collision.CompareTag("DangerObstacle"))
        {
            //TODO: Перенести урон и силу отталкивания в отдельный объект
            Debug.Log("DangerObstacle collided with player");
            playerHealth.GetDamage(5);
            Vector2 throwAwayVector = transform.position - collision.transform.position;
            playerRb.AddForce(throwAwayVector * 1000, ForceMode2D.Impulse);
        }
    }

   
}
