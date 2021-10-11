using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Translator : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //public void Update()
    //{

    //}

    public void Move(Vector2 velocity)
    {

        rb.velocity = velocity;
    }
}
