using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    PlayerHealth playerHealth;

    [SerializeField]
    private Text _healthText; // this is always null (causing an error)

    private void Start()
    {
        //if (playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>()) { Debug.Log("True"); }
        //else { Debug.LogError(this.name + "C"); }
        //playerHealth = GlobalReferences.Instance.PlayerHealth; //Added global reference to object
    }

    private void Update()
    {
        //healthBar.value = playerHealth.health;
        //string[] tmp = _healthText.text.Split(':');
        //_healthText.text = tmp[0] + ": " + healthBar.value;
    }
}
