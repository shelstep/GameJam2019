using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists.
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{

    public static GameManager instance;              //Static instance of GameManager which allows it to be accessed by any other script.
    private static int difficulty = 1;                                  //Current game difficulty
    private static int score = 0;                                  //Current score
    private static int highScore = 0;                                  //High score (should this persist between play sessions?)
    private static LifeManager lifeManager; 
    //public static LifeManager lifeManager;

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

        //Call the InitGame function to initialize the first level 
        InitGame();

        lifeManager = GameObject.FindObjectOfType<LifeManager>();
    }

    //Initializes the game
    void InitGame()
    {
        SceneManager.LoadScene("MainMenu");

    }



    //Update is called every frame.
    void Update()
    {

    }

    //Called by the Main Menu to start the game
    public static void StartGame()
    {
        //Create LifeManager
        //Instantiate(lifeManager, new Vector3(0, 0, 0), Quaternion.identity);
        //set difficulty to 1
        difficulty = 1;
        lifeManager.ResetLives();
        //create 108 thread objects for the scene transitions. 54 on each side, outside the bounds of the level. Don't Destroy on Load
        //Have threads engulf the screen
        //start microgame
        StartMicroGame();
    }

    public static void StartMicroGame()
    {
        SceneManager.LoadScene("DebugGame");
        //Randomly select a game
        //unload current scene, load randomly selected game
        //threads move off screen
    }

    public static void WonMicroGame()
    {
        //Threads engulf screen
        //increase score
        score++;
        StartMicroGame();
    }

    public static void LostMicroGame()
    {
        //Threads engulf screen
        //removes life
        int currentLives = lifeManager.LoseLife();
        //if lives = 0, then GameOver()
        if (currentLives == 0)
            GameOver();
        //otherwise start another microgame
        else
            StartMicroGame();
    }

    public static void GameOver()
    {
        //Threads engulf screen
        //unload current scene
        //load GameOver scene
        SceneManager.LoadScene("GameOver");
        //Check for high score
    }

}