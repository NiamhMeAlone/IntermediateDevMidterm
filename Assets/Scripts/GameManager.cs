using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Enemy enemy1, enemy2, enemy3;
    public Player player;
    public bool ended;
    public Text gameText;
    public Text healthText;
    public AudioSource source;

    private float timer = 3;

    private void Start()
    {
        ended = false;
        gameText.text = "Mission: eliminate all hostiles and get to evac point.";
        source.Play();
        DontDestroyOnLoad(source.gameObject);
    }

    void Update () {
        healthText.text = "Health: " + player.health;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if(timer > -5)
            {
                gameText.text = "Mission Start!";
                enemy1.alive = true;
                enemy2.alive = true;
                enemy3.alive = true;
                player.mobile = true;
                timer = -10;
            }
            else if (!enemy1.alive && !enemy2.alive && !enemy3.alive && timer > -11)
            {
                gameText.text = "Main objective complete, return to evac point.";
                ended = true;
            }
        }
        if (player.health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("LoseScene");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ended)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("EndScene");
        }
    }
}
