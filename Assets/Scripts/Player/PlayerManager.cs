using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.Mathematics;
using Cinemachine;
using JetBrains.Annotations;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static  Vector2 lastCheckPointPos =new Vector2(-24.93f,-6.39f); 
    public static int numberofCoins;
    public TextMeshProUGUI coinsText;
    public GameObject[] playerPrefabs;
    int characterIndex;
    public CinemachineVirtualCamera VCam;
    public GameObject pauseMenuScreen;
    // Start is called before the first frame update
    private void Awake() 
    {
        characterIndex =PlayerPrefs.GetInt("SelectedCharacter",0);
        GameObject player =Instantiate(playerPrefabs[characterIndex],lastCheckPointPos,quaternion.identity);
        VCam.m_Follow= player.transform;
        numberofCoins=PlayerPrefs.GetInt("NumberOfCoins",0);
        isGameOver=false;
        GameObject.FindGameObjectWithTag("Player").transform.position=lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text=numberofCoins.ToString();
        if(isGameOver)
        {   
            gameOverScreen.SetActive(true);
        }

    }
    public void ReplayLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
         
            if(gameOverScreen==true)
            {
                numberofCoins=0;
            }
        
    }
    public void PauseGame()
    {
        Time.timeScale=0;
        pauseMenuScreen.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale=1;
        pauseMenuScreen.SetActive(false);
        
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
