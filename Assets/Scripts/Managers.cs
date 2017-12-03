using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIManager), typeof(GameplayManager), typeof(EnemySpawner)), RequireComponent(typeof(AudioManager), typeof(VisualEffects))]
public class Managers : MonoBehaviour {

    public static Managers ins;

    private void Awake()
    {
        if (ins == null)
            ins = this;
        else if (ins != this)
            Destroy(gameObject);

        VFX = GetComponent<VisualEffects>();
        ES = GetComponent<EnemySpawner>();
        GPM = GetComponent<GameplayManager>();
        UIM = GetComponent<UIManager>();
        AM = GetComponent<AudioManager>();
    }

    [HideInInspector] public VisualEffects VFX;
    [HideInInspector] public AudioManager AM;
    [HideInInspector] public GameplayManager GPM;
    [HideInInspector] public EnemySpawner ES;
    [HideInInspector] public UIManager UIM;
}
