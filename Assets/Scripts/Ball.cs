using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        print(paddleToBallVector);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
        
    }

    // Update is called once per frame
    void Update () {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                print("Mouse clicked");

                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);

            }
        }
        
	}
}
