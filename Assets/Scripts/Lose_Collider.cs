using UnityEngine;
using System.Collections;

public class Lose_Collider : MonoBehaviour {

    public LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger");
        levelManager.LoadLevel("Win");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
