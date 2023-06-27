using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerControler : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    private GameObject timerTitle;
    public float timeRemaining = 0f;
    void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();       
        timerTitle = transform.GetChild(0).gameObject;
    }
  
    public void StartTimer(float time)
    {
        timeRemaining = time;
        timerTitle.SetActive(true);
        StartCoroutine(CountdownCoroutine());
    }
    private IEnumerator CountdownCoroutine()
    {
        while (timeRemaining > 0)
        {
            timerText.text = timeRemaining.ToString("F0");
            yield return new WaitForSeconds(1.0f);
            timeRemaining--;
        }      

        //set actvie false
        timerText.text = "";  
        timerTitle.SetActive(false);
    }
}
