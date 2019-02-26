using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    //Movement
    public float speed;
    public float jump;
    private float MoveVelocity;

    //Grounded vars
    bool grounded = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Scene2");
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }
        
        MoveVelocity = 0;

        //Left Right Movement
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            MoveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(MoveVelocity, GetComponent<Rigidbody2D>().velocity.y);


    }
    //check if grounded

    void OnTriggerEnter2D()
    {
        grounded = true;
    }
    void OnTriggerExit2D()
    {
        grounded = false;
    }

  void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Door")
        {
            if(SceneManager.GetActiveScene().name == "wat")
            {
                SceneManager.LoadScene("Scene2");
            }
            else
            {
                SceneManager.LoadScene("wat");
            }
            
        }
    }
}