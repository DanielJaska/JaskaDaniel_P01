using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 3f;

    [SerializeField] GameObject visuals;

    [Header("Feedback")]
    [SerializeField] TrailRenderer _trail = null;

    Rigidbody _rb = null;
    [SerializeField] Vector3 spawnPosition;

    [SerializeField] Transform enemyParent;

    [SerializeField] ParticleSystem particles;

    [SerializeField] GameObject projectile;

    [SerializeField] AudioClip deadClip;
    [SerializeField] AudioClip loseClip;
    [SerializeField] AudioClip winClip;

    [Header("UI Components")]
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text timerValue;
    [SerializeField] Text resetLevelText;
    [SerializeField] GameObject winScreen;

    public enum PlayerState
    {
        WIN,
        LOSE,
        PLAYING
    }

    public static PlayerState playerState;

    //public static bool isRespawning = false;

    private void Awake()
    {
        playerState = PlayerState.PLAYING;

        _rb = GetComponent<Rigidbody>();

        _trail.enabled = false;

        spawnPosition = transform.position;

        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(playerState == PlayerState.PLAYING)
        {
            MoveShip();
            TurnShip();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerState == PlayerState.PLAYING)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }

    void MoveShip()
    {
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;

        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        _rb.AddForce(moveDirection);
    }

    void TurnShip()
    {
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;

        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);

        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    public void Win()
    {
        AudioController.PlayClip(winClip);

        winScreen.SetActive(true);
        //isRespawning = true;
        playerState = PlayerState.WIN;
        DisablePlayer();
    }
    
    public void Kill()
    {
        gameOverScreen.SetActive(true);

        AudioController.PlayClip(deadClip);

        DisablePlayer();

        if(playerState == PlayerState.PLAYING)
        {
            StartCoroutine(Killed());
        }
        
    }

    private void DisablePlayer()
    {
        visuals.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        _rb.velocity = Vector3.zero;

        particles.Play();

        //for (int i = 0; i < enemyParent.childCount; i++)
        //{
        //    enemyParent.GetChild(i).GetComponent<EnemyController>().enabled = false;
        //}
    }

    IEnumerator Killed()
    {
        //isRespawning = true;
        playerState = PlayerState.LOSE;

        AudioController.PlayClip(loseClip);

        timerValue.text = "2";
        yield return new WaitForSeconds(1);
        timerValue.text = "1";
        yield return new WaitForSeconds(1);
        timerValue.text = "0";

        //resetLevelText.gameObject.SetActive(true);

        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeSceneIndex);

        //isRespawning = false;
        playerState = PlayerState.PLAYING;
    }

    public void SetSpeed(float speedChange)
    {
        _moveSpeed += speedChange;
    }

    public void SetBoosters(bool activeState)
    {
        _trail.enabled = activeState;
    }
}
