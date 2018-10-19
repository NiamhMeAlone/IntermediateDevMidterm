using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Enemy enemy1, enemy2, enemy3;
    public Player player;
    public bool ended;
    public Text text;

    private float timer = 3;

    private void Start()
    {
        ended = false;
        text.text = "Mission: eliminate all hostiles and get to evac point.";
        DontDestroyOnLoad(this);
    }

    void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if(timer > -5)
            {
                text.text = "Mission Start!";
                enemy1.alive = true;
                enemy2.alive = true;
                enemy3.alive = true;
                player.mobile = true;
                timer = -10;
            }
            else if (!enemy1.alive && !enemy2.alive && !enemy3.alive && timer > -11)
            {
                text.text = "Main objective complete, return to evac point.";
                ended = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ended)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
