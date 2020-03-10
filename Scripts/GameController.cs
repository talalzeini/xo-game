using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Player
{

public Image panel;
public Text text;
public Button button;
}
[System.Serializable]
public class PlayerColor
{

public Color panelColor;
public Color textColor;

}
public class GameController : MonoBehaviour
{
public Text[]buttonList;
private string playerSide;
public GameObject GameOverPanel;
public GameObject OPanel;
public GameObject XPanel;
public GameObject XText;
public GameObject OText;
public Text gameOverText;
private int moveCount;
public GameObject panel1;



public Player playerX;
public Player playerO;
public PlayerColor activePlayerColor;
public PlayerColor inactivePlayerColor;
    private object myPanel;
    internal object toggle;

    void Awake()
{
    SetGameControllerReferenceOnButtons();
        SetBoardInteractable(false);
        moveCount = 0;
    
}
void SetGameControllerReferenceOnButtons()
{
    for (int  i = 0; i < buttonList.Length; i++)
    {
buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
    }
}
   public void StartingSide(string startingSide)
    {
        playerSide = startingSide;
        if(playerSide == "X")
        {
            SetPlayerColors(playerX, playerO);
            panel1.SetActive(false);
        }
        else
        {
            SetPlayerColors(playerO, playerX);
            panel1.SetActive(false);
        }
        StartGame();
    }
    void StartGame()
    {
        SetBoardInteractable(true);
        SetPlayerButtons(false);
    }
public string GetPlayerSide()
{
return playerSide;
}
public void EndTurn()
{
	moveCount++;
    
 if ( buttonList[0].text == playerSide && buttonList[1].text == playerSide  && buttonList[2].text == playerSide)
{
    GameOver(playerSide);
}

else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide  && buttonList[5].text == playerSide)
{
    GameOver(playerSide);
}
else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide  && buttonList[8].text == playerSide)
{
    GameOver(playerSide);
}
else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide  && buttonList[6].text == playerSide)
{
    GameOver(playerSide);
}
 else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide  && buttonList[7].text == playerSide)
{
    GameOver(playerSide);
}
 else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide  && buttonList[8].text == playerSide)
{
    GameOver(playerSide);
}
else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide  && buttonList[6].text == playerSide)
{
    GameOver(playerSide);
}
else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide  && buttonList[8].text == playerSide)
{
    GameOver(playerSide);
}

else if (moveCount >= 9)
{
            GameOver("draw");
SetPlayerColorsInactive();
        }
ChangeSides();
}
void SetPlayerColors(Player newPlayer, Player oldPlayer)
{
newPlayer.panel.color = activePlayerColor.panelColor;
newPlayer.text.color = activePlayerColor.textColor;
oldPlayer.panel.color = inactivePlayerColor.panelColor;
oldPlayer.text.color = inactivePlayerColor.textColor;
}


void GameOver(string winningPlayer)
{
        SetBoardInteractable(false);
        if (winningPlayer == "draw")
        {
            SetGameOverText("GAME OVER");
            SetPlayerColorsInactive();

        }
        else
        {
            SetGameOverText(playerSide + " WINS");
        }
}
void ChangeSides()
{
playerSide = (playerSide == "X")? "O" : "X";

if (playerSide == "X")
{
SetPlayerColors(playerX, playerO);
}
else
{
SetPlayerColors(playerO, playerX);	
}
}
void SetGameOverText(string value)
{
GameOverPanel.SetActive(true);
XPanel.SetActive(false);
OPanel.SetActive(false);
OText.SetActive(false);
XText.SetActive(false);
gameOverText.text = value;
}
   public void SetBoardInteractable(bool toggle)
    {
        for ( int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

  public  void SetPlayerButtons(bool toggle)
    {
        playerX.button.interactable = toggle;
        playerO.button.interactable = toggle;
    }
    public void SetPlayerColorsInactive()
    {
        playerX.panel.color = inactivePlayerColor.panelColor;
        playerX.text.color = inactivePlayerColor.textColor;
        playerO.panel.color = inactivePlayerColor.panelColor;
        playerO.text.color = inactivePlayerColor.textColor;
    }
    public void Restart()
    {
        moveCount = 0;
        SceneManager.LoadScene("XO");
       SetBoardInteractable(false);
       SetPlayerButtons(true);
       SetPlayerColorsInactive();
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
        }
    }
}
