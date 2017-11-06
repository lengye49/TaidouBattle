public class PlayerInfo  {

    private int lv;
    private int school;

    public int Lv{
        get{ return lv; }
        set{lv = value;}
    }

    public int School{
        get{ return school;}
        set{ school = value;}
    }

    public PlayerInfo(int newLv,int newSchool){
        lv = newLv;
        school = newSchool;
    }
}
