using UnityEngine;
using System.Collections;

public class Lose_Collider : MonoBehaviour {

    private LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        levelManager.LoadLevel("Win");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

    

    // Use this for initialization
    void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
