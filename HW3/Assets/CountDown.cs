using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public static float timeLeft = 5.0f;
    float timerFl = 0.0f;
    public static string timer;
    string countDownStr;
    public static bool CanMove = false;
    bool countDown = true;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // print("Canmooooo:" + CanMove);
        timer = timerFl.ToString();
        countDownStr = timeLeft.ToString();

        if (timeLeft > 0)/////COUNTDOWN
        {
            timeLeft -= Time.deltaTime;
			transform.GetComponent<Text>().fontSize  = 50;
            transform.GetComponent<Text>().text = countDownStr[0].ToString();
			transform.GetComponent<Text>().transform.localPosition = new Vector3(88.8f,137.1f,0);
			
            CanMove = false;
        }

        if(timeLeft <= 0 || !countDown)//////TIMER
        {
            countDown = false;
			if(Parser.Stop == false)
			{
				timerFl += Time.deltaTime;
			}
				
            if (timeLeft <= 0) {

                CanMove = true;
				transform.GetComponent<Text>().fontSize  = 25;
                transform.GetComponent<Text>().text = "Time: " + timer;
				transform.GetComponent<Text>().transform.localPosition = new Vector3(53.3f,137.1f,0);
            }
        }
    }
}
