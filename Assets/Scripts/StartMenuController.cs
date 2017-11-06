using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StartMenuController : MonoBehaviour {

    public GameObject startPanel;
    public GameObject registerPanel;
    public GameObject loginPanel;
    public GameObject serverPanel;
    public GameObject charSelectPanel;
    public GameObject charCreatePanel;

    public GameObject[] charSelect;
    public Text[] t_CharSelect;
    public Image[] imgCharCreate;
    public Text[] t_CharCreate;

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
        UpdateCharSelectPanel();
    }

    void UpdateCharSelectPanel(){
        for (int i = 0; i < charSelect.Length; i++)
        {
            if (i == DataHandler.Instance._playerInfo.School)
                charSelect[i].SetActive(true);
            else
                charSelect[i].SetActive(false);
        }
        t_CharSelect[0].text = GameConfigs.SchoolNames[DataHandler.Instance._playerInfo.School];
        t_CharSelect[1].text = "Lv." + DataHandler.Instance._playerInfo.Lv;
        t_CharSelect[2].text = "公告";
        t_CharSelect[3].text = DataHandler.Instance.gameNotice;
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

    public void OnChangeChar(bool next){
        int lastIndex = thisCharIndex;
        SetChisCharIndex(next);

        float x = !next ? -853f : 0f;
        imgCharCreate[thisCharIndex].transform.localPosition = new Vector3(x, -62f, 0f);

        x = -479f;
        imgCharCreate[thisCharIndex].DOFade(1f, 0.5f);
        imgCharCreate[thisCharIndex].transform.DOLocalMoveX(x, 0.5f);

        x = !next ? 0f : -853f;
        imgCharCreate[lastIndex].DOFade(0f, 0.5f);
        imgCharCreate[lastIndex].transform.DOLocalMoveX(x, 0.5f);

        t_CharCreate[0].text = GameConfigs.SchoolNames[thisCharIndex];
        t_CharCreate[1].text = GameConfigs.SchoolDescs[thisCharIndex];
        t_CharCreate[2].text = GameConfigs.SchoolNames[thisCharIndex];
        int n = 0;
        if (next)
        {
            n = thisCharIndex + 1 > GameConfigs.SchoolList.Length - 1 ? 0 : thisCharIndex + 1;
            t_CharCreate[3].text ="<<" +GameConfigs.SchoolNames[lastIndex];
            t_CharCreate[4].text =  GameConfigs.SchoolNames[n]+">>";

        }
        else
        {
            n = thisCharIndex - 1 < 0 ? GameConfigs.SchoolList.Length - 1 : thisCharIndex - 1;
            t_CharCreate[3].text = "<<" + GameConfigs.SchoolNames[n];
            t_CharCreate[4].text = GameConfigs.SchoolNames[lastIndex] + ">>";
        }
        
    }

    void SetChisCharIndex(bool next){
        thisCharIndex = next ? (thisCharIndex + 1) : (thisCharIndex - 1);
        if (thisCharIndex < 0)
            thisCharIndex = GameConfigs.SchoolList.Length - 1;
        if (thisCharIndex > GameConfigs.SchoolList.Length - 1)
            thisCharIndex = 0;
    }
        

    public void OnConfirmCreateChar(){
        _move.ChangePanel(charCreatePanel, charSelectPanel);
        DataHandler.Instance._playerInfo.School = thisCharIndex;
        UpdateCharSelectPanel();
    }

    public void OnReturnFromCharCreate(){
        _move.ChangePanel(charCreatePanel, charSelectPanel);
    }
}
