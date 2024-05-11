using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    public override void TakeDamage(int damage)
    {
        Debug.Log($"{gameObject.name} takes {damage} damage!");
    }
}
