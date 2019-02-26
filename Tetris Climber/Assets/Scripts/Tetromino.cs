using UnityEngine;
using System.Collections;

public class Tetromino : MonoBehaviour{

    public float speed;
    private float MoveVelocity;
    public float rotationspeed;
    private float rotation;
    public GameObject[] groups;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveVelocity = 0;
        //Left Right Movement
        if (Input.GetKey(KeyCode.A))
        {
            MoveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveVelocity = speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnTriggerEnter2D();
        }

            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        //Rotation
        rotation = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E))
        {
            rotation = rotationspeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q))
        {
            rotation = -rotationspeed;
        }
        GetComponent<Rigidbody2D>().AddTorque(rotation , ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D()
    {
        enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        
    }
}