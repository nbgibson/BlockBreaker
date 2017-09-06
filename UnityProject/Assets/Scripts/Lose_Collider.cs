using UnityEngine;
using System.Collections;

public class Lose_Collider : MonoBehaviour {

    private LevelManager levelManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevel("Lose Screen");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //print("Collision");
    }
}
