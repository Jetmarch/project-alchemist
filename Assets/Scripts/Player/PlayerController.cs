using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float dashForse;
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool isDashActive;
    [SerializeField] private bool dashIsReady;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashMaxPlayerSpeed;
    [SerializeField] private float maxPlayerSpeed;
    [SerializeField] private int maxPlayerJumps;
    [SerializeField] private int currentPlayerJumps;

    [Header ("Inventory")]
    public Inventory inventory;
    [SerializeField] private InventoryUI inventoryUI;

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
        inventory = new Inventory(UseItem);
        inventoryUI.SetInventory(inventory);
        inventoryUI.SetPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayerSpriteOnInput();
        MovePlayer();
        Jump();
        Dash();
        IncreaseFallSpeed();
        LimitPlayerSpeed();
    }

    void UseItem(Item item)
    {
        Debug.Log("Item used: " + item.m_name);
        inventory.RemoveItem(item);
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
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
            currentPlayerJumps--;
        }
    }

    //Взял этот метод из видео:
    //https://www.youtube.com/watch?v=7KiK0Aqtmzc
    void IncreaseFallSpeed()
    {
        if(playerRb.velocity.y < 0)
        {
            playerRb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashIsReady)
        {
            if(playerSprite.flipX)
            {
                StartCoroutine(Dashing(Vector2.left));
                //playerRb.velocity = Vector2.left * dashForse;
            }
            else
            {
                StartCoroutine(Dashing(Vector2.right));
                //playerRb.velocity = Vector2.right * dashForse;
            }
            
            StartCoroutine(DashCooldown());
        }
    }

    IEnumerator Dashing(Vector2 side)
    {
        float timeLeftForDash = dashDuration;
        isDashActive = true;
        while (isDashActive)
        {
            playerRb.AddForce(side * dashForse, ForceMode2D.Impulse);
            yield return new WaitForFixedUpdate();
            timeLeftForDash -= Time.fixedDeltaTime;

            if(timeLeftForDash <= 0)
            {
                isDashActive = false;
            }
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
        if (isDashActive)
        {
            if (playerRb.velocity.magnitude > dashMaxPlayerSpeed)
            {
                playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, dashMaxPlayerSpeed);
            }
        }
        else
        {
            if (playerRb.velocity.magnitude > maxPlayerSpeed)
            {
                playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, maxPlayerSpeed);
            }
        }
    }

    IEnumerator DashCooldown()
    {
        dashIsReady = false;
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

        if (collision.gameObject.CompareTag("DangerObstacle"))
        {
            //TODO: Перенести урон и силу отталкивания в отдельный объект
            playerHealth.GetDamage(5);
            Vector2 throwAwayVector = transform.position - collision.transform.position;
            playerRb.AddForce(throwAwayVector * 1000, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredient"))
        {
            var item = collision.GetComponent<ItemWorld>();
            //Добавляем в инвентарь игрока полученный ингредиент
            inventory.AddItem(item.item);

            item.DestroySelf();
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
   
}
