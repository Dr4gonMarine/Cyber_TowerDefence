using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEffect : MonoBehaviour
{
    ParticleSystem _particleSystem;
 
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void EmitParticles()
    {
        _particleSystem.Play();
    }
    
}
