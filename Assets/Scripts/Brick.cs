using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public int maxHits;
    public Sprite[] hitSprites;
    public GameObject smoke;
    public static int breakableCount = 0; //One instance of this varible so long as there is a brick in the scene.
    public AudioClip crack;

    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;
    // Use this for initialization
    void Start () {
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        levelManager = GameObject.FindObjectOfType<LevelManager>();

    }

    // Update is called once per frame
    void Update () {
	   
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            PuffSmoke();
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing!");
        }
    }
}
