using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public int expValue = 1;

    //Logic
    public float triggerLenght= 1;
    public float chaseLenght = 5;
    private bool chasing;
    private bool collidingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPostion;

    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPostion = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        //Is the player in range?
        if(Vector3.Distance(playerTransform.position, startingPostion) < chaseLenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPostion) < triggerLenght)
                chasing = true;

            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
                else
                {
                    UpdateMotor(startingPostion - transform.position);
                }
            }
            else
            {
                UpdateMotor(startingPostion - transform.position);
                chasing = false;
            }
        }

        //Check for overlaps
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

           if(hits[i].tag == "Fighter" && hits[i].name == "Player"){
                collidingWithPlayer = true;
            }
            hits[i] = null;
        }

        UpdateMotor(Vector3.zero);
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.experience += expValue;
        GameManager.instance.ShowText("+" + expValue + " xp", 30, Color.magenta,transform.position, Vector3.up * 40, 1.0F);
    }
}
