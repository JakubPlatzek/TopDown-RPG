using UnityEngine;

public class Weapon : Collidable
{
    //damage structure
    public int damagePoint = 1;
    public float pushForce = 2.0F;


    //Upgrade
    public int weaponLvl = 0;
    private SpriteRenderer spriteRenderer;

    //Swing
    private Animator anim;
    private float cooldown = 0.5F;
    private float lastSwing;

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D col)
    {
        if(col.tag == "Fighter")
        {
            if (col.name == "Player")
                return;

            //Create damage object and send it to the fighter we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            col.SendMessage("ReceiveDamage", dmg);

                Debug.Log(col.name);
            }
        }
        

    private void Swing()
    {
        anim.SetTrigger("Swing");
    }

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

}
