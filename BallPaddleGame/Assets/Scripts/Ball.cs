using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private float speed;
    [SerializeField] private GameObject ballHitSoundObject;
    private new Rigidbody2D rigidbody;
    private bool checkingForStuck;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        AddStartingForce();
    }

    private void Update()
    {
        if (!checkingForStuck)
        {
            CheckForStuck();
        }
    }

    private void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);

        Vector2 direction = new Vector2(x, y);
        rigidbody.AddForce(direction * speed);
    }

    public void IncreaseSpeed(float amount)
    {
        rigidbody.velocity /= speed;
        speed += amount;
        rigidbody.velocity *= speed;
    }

    private void CheckForStuck()
    {
        if(transform.position.x >= 8.5 || transform.position.x <= -8.5)
        {
            checkingForStuck = true;
            StartCoroutine(ConfirmStuck(transform.position.x));
        }
    }

    private IEnumerator ConfirmStuck(float currentX)
    {
        yield return new WaitForSeconds(1);

        if(transform.position.x == currentX)
        {
            rigidbody.velocity = new Vector2(-(transform.position.x / 8), rigidbody.velocity.y);
        }

        checkingForStuck = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject soundObject = Instantiate(ballHitSoundObject);
        Destroy(soundObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
        FindObjectOfType<GameManager>().DisplayEndScore();
    }
}
