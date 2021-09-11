using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    public int damage = 1;
    public int pushForce = 5;

    protected override void OnCollide(Collider2D col)
    {
        if(col.tag == "Fighter" && col.name == "Player")
        {
            //Create a new damage object, before sending it to the player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            col.SendMessage("ReceiveDamage", dmg);
        }
    }
}
