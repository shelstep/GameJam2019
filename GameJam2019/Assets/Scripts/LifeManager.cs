using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;              //Static instance of LifeManager which allows it to be accessed by any other script.
    private static int lifeCount = 0;
    public const int MAX_LIVES = 3;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //set lives to 3
        lifeCount = MAX_LIVES;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //Draw thread spools based on number of lives
    }

    public static void resetLives()
    {
        lifeCount = MAX_LIVES;
    }

    public static int loseLife()
    {
        if (lifeCount > 0)
            lifeCount--;
        return lifeCount;    
    }
}
