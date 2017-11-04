using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour {

    public GameObject startPanel;
    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject serverPanel;
    public GameObject charSelectPanel;
    public GameObject charCreatePanel;

    private MovementHandler _move;
    private int thisCharIndex;

	void Start () {
        _move = GetComponent<MovementHandler>();
        _move.ShowPanel(startPanel);
	}

    public void OnChangeUser(){
        _move.ChangePanel(startPanel, loginPanel);
    }

    public void OnChangeServer(){
        _move.ChangePanel(startPanel, serverPanel);
    }

    public void OnStartGame(){
        _move.ChangePanel(startPanel, charSelectPanel);
    }

    public void OnConfirmUser(){
        _move.ChangePanel(loginPanel, startPanel);
        //确认用户
        //ToDo
    }

    public void OnChangeToRegisterFromLogin(){
        _move.ChangePanel(loginPanel, registerPanel);
    }

    public void OnCloseLogin(){
        _move.ChangePanel(loginPanel, startPanel);
    }

    public void OnRegisterUser(){
        _move.ChangePanel(registerPanel, startPanel);
        //确认新用户
        //ToDo
    }

    public void OnRegisterCancel(){
        _move.ChangePanel(registerPanel, startPanel);
    }

    public void OnCloseRegister(){
        _move.ChangePanel(registerPanel, startPanel);
    }

    public void OnCloseServer(){
        _move.ChangePanel(serverPanel, startPanel);
    }

    public void OnEnterGame(){
        //进入游戏
    }

    public void OnCreateChar(){
        _move.ChangePanel(charSelectPanel, charCreatePanel);
        thisCharIndex = 0;
    } 

    public void OnNextChar(){
        if (thisCharIndex < GameConfigs.SchoolList.Length - 1)
        {
            thisCharIndex++;
        }
        else
        {
            thisCharIndex = 0;
        }
            
        _move.ShowCharacter(thisCharIndex, true, charCreatePanel.transform);
    }

    public void OnLastChar(){
        if (thisCharIndex > 0)
        {
            thisCharIndex--;
        }
        else
        {
            thisCharIndex = GameConfigs.SchoolList.Length - 1;
        }

        _move.ShowCharacter(thisCharIndex, false, charCreatePanel.transform);
    }


    public void OnConfirmCreateChar(){
        _move.ChangePanel(charCreatePanel, charSelectPanel);

    }

    public void OnReturnFromCharCreate(){
        _move.ChangePanel(charCreatePanel, charSelectPanel);
    }
}
