using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    public GameObject SpawnParticles;
    public GameObject DeathParticles;

    public void Spawn()
    {
        SpawnParticles.SetActive(true);
    }

    public void Death()
    {
        DeathParticles.SetActive(true);
    }
}
