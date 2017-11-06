using UnityEngine;

public class DataHandler: Singleton<DataHandler>{
    public PlayerInfo _playerInfo;
    public string gameNotice = "欢迎大家来到游戏！";
    void Awake(){
        this.init();
    }

    public void init(){
        _playerInfo = new PlayerInfo(1, 1);
    }
}
