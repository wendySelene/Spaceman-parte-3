using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour{

    public GameState currentGameState = GameState.menu;
    
    public static GameManager sharedInstance;

    private PlayerController controller;

    void Awake() 
    {
        if(sharedInstance == null)
        {
        sharedInstance = this;    
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
     controller = GameObject.Find("Player").GetComponent<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit") && currentGameState != GameState.inGame ){
            StartGame();
        }
    }
    //Empezar el juego
    public void StartGame(){
        SetGameState(GameState.inGame);
    }
    //Muerte del jugador
    public void GameOver(){
        SetGameState(GameState.gameOver);
    }
    //Regresar al menu
    public void BackToMenu(){
        SetGameState(GameState.menu);
    }
    private void SetGameState(GameState newGameState){
        if (newGameState == GameState.menu)
        {
            //TODO: colocar la logica del menu
        }else if(newGameState == GameState.inGame){
            //TODO: hay que preparar la escena para jugar 
            LevelManager.sharedInstance.RemoveAllLevelBlocks();
            LevelManager.sharedInstance.GenerateInitialBlocks();
            controller.StartGame();
            
            
        }else if (newGameState == GameState.gameOver){
            //TODO: preparar el juego para el Game Over 
        }

        this.currentGameState = newGameState;
    }

  
}
