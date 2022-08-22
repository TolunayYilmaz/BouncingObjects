using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    // Start is called before the first frame update
    private GameManager gameManager;
    public GameObject TitleScreen;
    public int diffucultyMode;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(diffuculty);// method that works when button is pressed
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }


    private void diffuculty()//difficulty center
    {
        gameManager.StartGame(diffucultyMode);
        TitleScreen.SetActive(false);
        
    }

}
