using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public int maxHits;
    public Sprite[] hitSprites;

    private int timesHit;

	// Use this for initialization
	void Start () {
        timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	   
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        timesHit++;
        if(timesHit >= maxHits)
        {
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
