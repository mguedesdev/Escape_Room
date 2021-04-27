using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeValue = 90;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private GameObject pnlGameOver;
    [SerializeField]
    private GameObject pnlMenu;
    [SerializeField]
    public int pointsPuzzle1, pointsPuzzle2, pointsPuzzle3;
    [SerializeField]
    public Image[] key;

    public int points;
    
    public bool loss = false;

    void Start()
    {
        points = 0;
        pointsPuzzle1 = 0;
        pointsPuzzle2 = 0;
        pointsPuzzle3 = 0;
    }

    
    void Update()
    {
        Timer();
        Menu();
        HudKey();
    }

    void Timer(){
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
            pnlGameOver.SetActive(true);
            Time.timeScale = 0f;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Restart(){
        Time.timeScale = 1f;
        timeValue = 5;
        SceneManager.LoadScene(0);
        
    }

    public void Close(){
        Application.Quit();
        
    }

    public void AddPoint(){
        points++;
    }    

    void Menu(){
        if (Input.GetKeyDown("escape")){
            if(Time.timeScale == 0f){
                Time.timeScale = 1f;
                pnlMenu.SetActive(false);
            }
            else{
                Time.timeScale = 0f;
                pnlMenu.SetActive(true);
            }
        }
    }

    public void ClosePuzzle(GameObject puzzle){
        puzzle.SetActive(false);
    }

    public void HudKey(){
        
        if(points > 0 )
        {
            key[points-1].enabled = true;
        }
    }
}
