using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnLocation;

    public GameObject playerRagdoll;

    public bool isDead = false;

    public float deadTimer = 4f;
    public float deadTimerTime = 4f;

    private void Update()
    {
        if (deadTimer <= 0 && isDead == true)
        {
            Dead();
        }

        if (deadTimer <= 0)
            deadTimer = 0f;

        deadTimer -= 1 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ragdoll")
        {
            Destroy(other.gameObject);

            isDead = true;
        }
    }

    void Dead()
    {
        isDead = false;
        Instantiate(playerRagdoll, respawnLocation.transform.position, Quaternion.identity);
        deadTimer = deadTimerTime;
    }
}
