﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{

    [SerializeField] GameObject eneryPrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenSpawns = 0.5f;

    [SerializeField] float spawnRandomFactor = 0.3f;

    [SerializeField] int numberOfEnemies = 5;

    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return eneryPrefab;
    }

}
