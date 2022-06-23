using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance { get; private set; }

    #region Player Movement
    Rigidbody2D rigidBody;
    public SpriteRenderer sr;
    public float PlayerSpeed = 5f;
    #endregion

    #region Player Info
    public Text scoreText;
    private int health;
    private int score;
    public int Health { get => health; set => health = value; }
    public int Score { get => score; set => score = value; }
    #endregion

    public GameOverScreen gameOver;
    [SerializeField] private bool isPlaying = true;
    [SerializeField] private float slowless = 11f;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent();
        PlayerReset();
    }
    void Update()
    {
        EndGame();
    }
    void GetComponent()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void PlayerReset()
    {
        health = 3;
        score = 0;
    }
    void PlayerMovement()
    {
        if (isPlaying)
        {
            float x = Input.GetAxis("Horizontal");
            Vector2 move = new Vector2(PlayerSpeed * x, 0);
            rigidBody.velocity = move;
        }

    }
    void EndGame()
    {
        scoreText.text = Score.ToString();
        if (Health <= 0 && isPlaying)
        {
            StartCoroutine(RestartLevel());
            isPlaying = !isPlaying;
        }
        else
        {
            PlayerMovement();
        }
    }
    IEnumerator RestartLevel()
    {
        Time.timeScale = 1f / slowless;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowless;

        yield return new WaitForSeconds(1f / slowless);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowless;

        gameOver.Setup(Score);
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
    public void TakeScore(int score)
    {
        Score += score;
    }
}
