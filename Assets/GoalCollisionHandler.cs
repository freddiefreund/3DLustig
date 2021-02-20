using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollisionHandler : MonoBehaviour
{
    [SerializeField] private int scoreValue;
    [SerializeField] private ParticleSystem _succesParticleSystem;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _audioSource.Play();
        _succesParticleSystem.Play();
        Debug.Log("You Scored: " + scoreValue + " Points!");
    }
}
