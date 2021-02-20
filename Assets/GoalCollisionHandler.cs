using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollisionHandler : MonoBehaviour
{
    [SerializeField] private int scoreValue;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("You Scored: " + scoreValue + " Points!");
        }
    }
}
