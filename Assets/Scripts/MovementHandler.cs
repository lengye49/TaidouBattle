using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementHandler : MonoBehaviour {

    private float timeOfMovement = 0.5f;
    private float timeWaitToShow = 0.2f;

    private Vector3 charPosLeft = new Vector3(-853f, -62f, 0f);
    private Vector3 charPosRight = new Vector3(0f, -62f, 0f);
    private Vector3 charSelectedPos = new Vector3(-479f, -62f, 0f);   

    /// <summary>
    /// Shows a panel.
    /// </summary>
    /// <param name="newPanel">New panel.</param>
    public void ShowPanel(GameObject newPanel){
        newPanel.SetActive(true);
        newPanel.transform.localScale = Vector3.zero;
        Hashtable args = new Hashtable();
        args.Add("scale",new Vector3(1,1,1));
        args.Add("time", timeOfMovement);
        args.Add("loopType", iTween.LoopType.none);
        iTween.ScaleTo(newPanel, args);
    }
        
    /// <summary>
    /// Hides a panel.
    /// </summary>
    /// <param name="oldPanel">Old panel.</param>
    public void HidePanel(GameObject oldPanel){
        Hashtable args = new Hashtable();
        args.Add("scale",Vector3.zero);
        args.Add("time", timeOfMovement);
        args.Add("loopType", iTween.LoopType.none);
        iTween.ScaleTo(oldPanel, args);
        oldPanel.SetActive(false);
    }

    /// <summary>
    /// Hides an old panel and show a new one.
    /// </summary>
    /// <param name="oldPanel">Old panel.</param>
    /// <param name="newPanel">New panel.</param>
    public void ChangePanel(GameObject oldPanel,GameObject newPanel){
        HidePanel(oldPanel);
        StartCoroutine(WaitAndShowNewPanel(newPanel));
    }

    IEnumerator WaitAndShowNewPanel(GameObject newPanel){
        yield return new WaitForSeconds(timeWaitToShow);
        ShowPanel(newPanel);
    }

    public void ShowCharacter(int charIndex,bool next,Transform p){
        GameObject thisChar = p.Find("Character/CharSelected").gameObject;
        GameObject prefb = Resources.Load("Prefabs/CharPrefab_" + charIndex, typeof(GameObject)) as GameObject;

        GameObject newChar = Instantiate(prefb) as GameObject;
        newChar.SetActive(true);
        newChar.transform.SetParent(p);
        newChar.transform.localScale = Vector3.one;
        newChar.transform.localPosition = next ? charPosRight : charPosLeft;
        newChar.name = "CharSelected";

        Hashtable argsIn = new Hashtable();
        argsIn.Add("x", charSelectedPos.x);
        argsIn.Add("time", timeOfMovement);
        argsIn.Add("loopType", "none");

        Hashtable argsOut = new Hashtable();
        argsOut = argsIn;
        argsOut["x"] = next ? charPosRight.x : charPosLeft.x;

        iTween.MoveTo(thisChar, argsOut);
        iTween.MoveTo(newChar, argsIn);
        Destroy(thisChar, 0.5f);

        Text infoTitle = p.Find("Character/Info/t_InfoTitle").gameObject.GetComponent<Text>();
        Text infoContent = p.Find("Character/Info/t_InfoContent").gameObject.GetComponent<Text>();
        infoTitle.text="唐门";
        infoContent.text="唐门不厉害的。<b>真的</b>。他们会放 <i>暗器</i>。不信你看，<b><i>biubiubiu</i></b>\n如果把他们当敌人，那是很<color=red>危险</color>的！<size=50><color=red>非常危险！</color></size>";
    }

    public void ShowCharacter(int charIndex, Transform p){
    //更换prefab和信息
        GameObject thisChar = p.Find("Character/CharSelected").gameObject;
        DestroyImmediate(thisChar);

        GameObject prefb = Resources.Load("CharPrefab_" + charIndex, typeof(GameObject)) as GameObject;
        GameObject newChar = Instantiate(prefb) as GameObject;
        newChar.SetActive(true);
        newChar.transform.SetParent(p);
        newChar.transform.localScale = Vector3.one;
        newChar.transform.localPosition = charSelectedPos;
        newChar.name = "CharSelected";

        Text charName = p.Find("t_CharName").gameObject.GetComponent<Text>();
        Text charLv = p.Find("t_CharLv").gameObject.GetComponent<Text>();
        charName.text = "唐门";
        charLv.text = "Lv.1";
    }
}
