using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;              //Static instance of LifeManager which allows it to be accessed by any other script.
    private static int lifeCount = 0;
    public const int MAX_LIVES = 3;
    private static GameObject[] lives = new GameObject[MAX_LIVES];
    public GameObject life;


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

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }


    public void ResetLives()
    {
        lifeCount = MAX_LIVES;
        for (int i = MAX_LIVES; i >= 1; i--)
        {
            GameObject temp = Instantiate(life, new Vector3(((MAX_LIVES - i) * (float)-1.50 - 4), (float)-3.75, 1), Quaternion.identity);
            DontDestroyOnLoad(temp);
            lives[i - 1] = temp;
        }
    }

    public int LoseLife()
    {
        if (lifeCount > 0)
            Destroy(lives[lifeCount-1]);
            lifeCount--;
        return lifeCount;    
    }
}
