using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour {

    public GameObject startPanel;
    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject serverPanel;
    private MovementHandler _move;

	// Use this for initialization
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
        //开始游戏
        //ToDo
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
}
