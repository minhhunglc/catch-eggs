using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    PlayerMove playerMove;
    ItemChecker itemChecker;
    SpriteRenderer sr;

    public GameObject[] walls;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        itemChecker = GameObject.Find("Player").GetComponent<ItemChecker>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Good")
        {
            playerMove.TakeDamage(1);
            StartCoroutine(RedZone());
            itemChecker.CheckExplosion();
            Destroy(collision.gameObject, 0.5f);
        }

        if (collision.gameObject.tag == "Bad")
        {
            Destroy(collision.gameObject, 0.5f);
        }

    }
    IEnumerator RedZone()
    {
        WallColor(Color.red);
        sr.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        WallColor(Color.white);
        sr.material.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        WallColor(Color.red);
        sr.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        WallColor(Color.white);
        sr.material.color = Color.white;

    }
    void WallColor(Color cl)
    {
        walls[0].GetComponent<SpriteRenderer>().material.color = cl;
        walls[1].GetComponent<SpriteRenderer>().material.color = cl;
    }

}
