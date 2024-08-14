using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables 
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    private float YUpperBound = -11;
    private float YLowerBound = -17.5f;
    private float ZBound = -2;
    [SerializeField] private float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            MoveYAxis();
        }
        YBounds();
    }

    void MoveXAxis() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    void MoveYAxis() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    void YBounds() {
        if (transform.position.y > YUpperBound) {
            transform.position = new Vector3(transform.position.x, YUpperBound, ZBound);
        }

        if (transform.position.y < YLowerBound) {
            transform.position = new Vector3(transform.position.x, YLowerBound, ZBound);
        }
    }

}
