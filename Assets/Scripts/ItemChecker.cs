using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemChecker : MonoBehaviour
{
    PlayerMove playerMove;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Good")
        {
            StartCoroutine(PlayerCheck(Color.yellow, Color.white));
            playerMove.TakeScore(20);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bad")
        {
            StartCoroutine(PlayerCheck(Color.red, Color.white));
            playerMove.TakeDamage(1);
            CheckExplosion();
            Destroy(collision.gameObject);
        }
    }
    public void CheckExplosion()
    {
        if (playerMove.Health <= 0)
        {
            Explode();
        }
    }
    void Explode()
    {
        GameObject explosionClone = Instantiate(explosion, this.gameObject.transform.position, gameObject.transform.rotation);
        Destroy(explosionClone, 1f);

    }
    IEnumerator PlayerCheck(Color cl1, Color cl2)
    {
        playerMove.sr.material.color = cl1;
        yield return new WaitForSeconds(0.1f);
        playerMove.sr.material.color = cl2;
        yield return new WaitForSeconds(0.1f);
        playerMove.sr.material.color = cl1;
        yield return new WaitForSeconds(0.1f);
        playerMove.sr.material.color = cl2;
    }
}
