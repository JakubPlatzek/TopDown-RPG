using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
                    
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSpriteS;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;

    public FloatingTextManger floatingTextManager;


    //Logic
    public int pesos;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Save state
    /*
     * INT preferedSkin
     * INT pesos
     * INT experience
     * INT weaponLevel
     */
    public void SaveState()
    {
               string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene sc, LoadSceneMode loadSceneMode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');
        //0|10|15|2
        //Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change weapon level

        Debug.Log("LoadState");
    }
 
}
