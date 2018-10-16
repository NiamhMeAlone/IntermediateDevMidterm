using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Enemy enemy1, enemy2;
	
	void Update () {
        if (!enemy1.alive && !enemy2.alive)
        {
            SceneManager.LoadScene("EndScene");
        }
	}
}
