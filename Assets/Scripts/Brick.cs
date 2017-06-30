using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public int maxHits;
    public Sprite[] hitSprites;
    public GameObject smoke;

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
            PuffSmoke();
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
