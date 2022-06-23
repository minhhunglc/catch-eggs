using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform rightSide;

    [SerializeField] private GameObject[] items;

    PlayerMove playerMove;


    // Start is called before the first frame update
    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMove>();
        Invoke();
    }
    void Update()
    {
        if (playerMove.Health <= 0)
            CancelInvoke();
    }
    void Invoke()
    {
        InvokeRepeating("Spawn", 2, 1f);

    }
    void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(gameObject.transform.position.x, rightSide.position.x), gameObject.transform.position.y, 0);
        Instantiate(items[Random.Range(0, items.Length)], pos, gameObject.transform.rotation);
    }
}
