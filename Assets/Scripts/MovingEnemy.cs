using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy {

    public float moveSpeed;

    void Update()
    {
        if (alive)
        {
            Vector3 dir2Player = player.position - transform.position;
            Ray playRay = new Ray(transform.position, player.position - transform.position);
            if (Physics.Raycast(playRay, out hit, 1000))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    dir2Player.y = 0;
                    transform.forward = dir2Player.normalized;
                    if (timer <= 0)
                    {
                        Shoot();
                    }
                }
                else
                {
                    Ray detectionRay = new Ray(transform.position, transform.forward);

                    float maxRaycastDistance = 1f;

                    // STEP 3: visualize the raycast
                    Debug.DrawRay(detectionRay.origin, detectionRay.direction * maxRaycastDistance, Color.cyan);

                    // STEP 4: shoooot the raycast!!!
                    if (Physics.Raycast(detectionRay, maxRaycastDistance))
                    {
                        // if raycast is true = there's a wall in front of us
                        // randomly turn left or right?
                        int randomNumber = Random.Range(0, 100); // rand num from 0-100
                        if (randomNumber < 50)
                        { // 50% chance of turning left?
                            transform.Rotate(0f, -90f, 0f);
                        }
                        else
                        { // 50% chance of turning right
                            transform.Rotate(0f, 90f, 0f);
                        }
                    }
                    else
                    {
                        // if raycast is false = nothing in raycast's way
                        // so go forward
                        transform.Translate(0f, 0f, Time.deltaTime * moveSpeed);
                    }
                }
            }
            timer -= Time.deltaTime;
        }
    }
}
