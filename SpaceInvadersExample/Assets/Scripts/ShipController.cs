using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private int _random;
    private Rigidbody2D _rigidBody;
    private Vector2 _vectorMovement;

    [Header("Need for SPEED!!")]
    [Range(-3, 3)]
    public float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _random = Random.Range(-10, 10);
        Debug.Log($"Random Value: {_random}");
        this.transform.position = new Vector2(_random, -4f);
        Debug.Log($"Position X : {this.transform.position.x}");
    }

    // Update is called once per frame
    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        _vectorMovement = new Vector2(movementHorizontal, 0f);
    }

    // FixedUpdate se llama en cada fixed frame-rate frame. (50 llamadas por segundo, por defecto)
    void FixedUpdate()
    {
        _rigidBody.AddForce(_vectorMovement * Speed * 5f);
    }
}
