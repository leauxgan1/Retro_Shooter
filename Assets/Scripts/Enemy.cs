using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy
{   
    public float Speed = 1.0f;
    public float MaxHealth = 10.0f;
    public float CurrentHealth;
    public float Damage = 1.0f;
    public float viewDistance = 20.0f;
    public GameObject player;

    public abstract void attack(); 

    public abstract float MAX_HEALTH { get; }
    public abstract float CURRENT_HEALTH { get; }
    public abstract float DAMAGE_HEALTH { get; }
    public abstract float VIEW_DISTANCE { get; }
}
