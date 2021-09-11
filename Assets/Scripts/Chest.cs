using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public Sprite fullChest;
    public int pesosAmount = 10;
  
    protected override void OnCollect()
    {
        if (!collected)
        {
            if(pesosAmount == 0)
            {
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                
            }
            else if(pesosAmount > 0)
            {
                GetComponent<SpriteRenderer>().sprite = fullChest;
                if (Input.GetKey(KeyCode.E))
                {
                    collected = true;
                    GetComponent<SpriteRenderer>().sprite = emptyChest;
                    GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 30, 1.5F);
                }
            }
            
       
           
        }
     
    }


}
