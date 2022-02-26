using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{
    public int dmgRate;
    public Rigidbody2D player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && !PlayerStats.isImmune)
        {
            dealDmg(dmgRate);           
            PlayerStats.isImmune = true;
            Debug.Log(PlayerStats.hp);
        }
    }

    void dealDmg(int x)
    {
        PlayerStats.hp -= x;
    }


}
