using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // variables
    [SerializeField] private float speed = 10.0f;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    { 
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
        }
    }
}
