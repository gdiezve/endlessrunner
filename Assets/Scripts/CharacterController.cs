using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public bool isDead = false;
    public ScoreManager scoreManager;

    private Rigidbody2D rb;

    private Vector2 movement;
    private int changeSpeedScore = 10;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0) {
            movement.y = 0;
        }

        if (movement != Vector2.zero) {
            Move();
        }

        if (scoreManager.GetScore() == changeSpeedScore) {
            moveSpeed += 1f;
            changeSpeedScore += 10;
        }
    }

    private void Move() {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            isDead = true;
        }
        else if (collision.gameObject.CompareTag("Trash")) {
            ScoreManager.instance.ChangeScore(+1);
            Debug.Log("Trash point");
            Destroy(collision.gameObject);
        }
    }
}
