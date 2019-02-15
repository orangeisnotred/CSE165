using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public static float timeLeft = 5.0f;
    float timerFl = 0.0f;
    string timer;
    string countDownStr;
    public static bool CanMove = false;
    bool countDown = true;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        timer = timerFl.ToString();
        countDownStr = timeLeft.ToString();

        if (timeLeft > 0)/////COUNTDOWN
        {
            timeLeft -= Time.deltaTime;
            transform.GetComponent<Text>().text = countDownStr[0].ToString();
            CanMove = false;
        }

        if(timeLeft <= 0 || !countDown)//////TIMER
        {
            countDown = false;
            timerFl += Time.deltaTime;
            if (timeLeft <= 0) {

                CanMove = true;
                transform.GetComponent<Text>().text = timer;
            }
        }
    }
}
