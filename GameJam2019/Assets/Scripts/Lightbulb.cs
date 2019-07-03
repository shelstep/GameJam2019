using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Lightbulb : MonoBehaviour
{
    public const float MOVE_DISTANCE = 0.07f;
    public static int counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 position = this.transform.position;
        if (Math.Abs(position.y) >= 1.4f)
            WonGame();
        if (counter > 4)
            counter = 1;
        //This gives a triangular wave of period 6, oscillating between 3 and 0.
        //y = abs((x++ % 6) - 3);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            position.y = position.y - MOVE_DISTANCE;
            //position.x = Math.Abs(((position.y) % 0.28f) + 0.14f) - 0.07f;
            if (counter == 4)
            {
                //CCW
                this.transform.Rotate(Vector3.forward * 30);
            }
            else if (counter == 3)
            {
                //CW
                this.transform.Rotate(Vector3.forward * -30);
            }
            else if (counter == 2)
            {
                //CW
                this.transform.Rotate(Vector3.forward * -30);
            }
            else 
            {
                //CCW
                this.transform.Rotate(Vector3.forward * 30);
            }
            this.transform.position = position;
            counter++;
        }
    }

    // Won Lightbulb Game
    void WonGame()
    {
        //GameManager.WonMicroGame();
        GameManager.GameOver();
    }
}
