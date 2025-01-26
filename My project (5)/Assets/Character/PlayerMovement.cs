using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float moveSpeed = 5f; // Скорость передвижения
    public float jumpForce = 10f; // Сила прыжка
    private bool isGrounded; // Проверка на контакт с землёй

    void Start()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Обработка движения влево и вправо
        float horizontalInput = Input.GetAxis("Horizontal"); // Получаем ввод по оси X
        Vector2 newVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);
        body.linearVelocity = newVelocity;

        // Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = false;
        }
    }
}