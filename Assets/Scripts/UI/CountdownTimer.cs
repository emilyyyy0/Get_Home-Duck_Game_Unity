using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] public float timeRemaining;
    public TextMeshProUGUI timeText;

    private bool timerOn = true;

    // Start is called before the first frame update
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (timerOn && timeRemaining > 0)
        {
            timeRemaining -= Time.fixedDeltaTime;
            if (timeRemaining < 0) timeRemaining = 0;
            updateTimerDisplay(timeRemaining);
            if (timeRemaining <= 30f) timeText.color = Color.red;
        }
        else if (timerOn)
        {
            timeRemaining = 0;
            SceneManager.LoadScene(2);
            timerOn = false;
            updateTimerDisplay(timeRemaining);
            // gameover scene
        }
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }


    private void updateTimerDisplay(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    //glowing ducks. eat batteries. 
}