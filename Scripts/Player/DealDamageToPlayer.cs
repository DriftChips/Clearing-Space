using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToPlayer : MonoBehaviour
{
   public void sendDamage (int damage)
    {
        PlayerHealth playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerstats.TakeDamage(damage);
    }
}
