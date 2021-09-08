using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool isOnGround;
    public bool dashIsReady;
    public float dashCooldown;

    private Rigidbody2D playerRb;
    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        dashIsReady = true;
        playerRb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashIsReady)
        {
            Debug.Log("Dash!");
            dashIsReady = false;
            StartCoroutine(DashCooldown());
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
            playerRb.AddForce(throwAwayVector * 200, ForceMode2D.Impulse);
        }
    }

   
}
