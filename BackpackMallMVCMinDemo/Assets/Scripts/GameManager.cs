using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {

        ///加载所有的数据信息
        ModeManager.GetT.AllModelLoad();
        UIManager.GetT.OpenUI(ShowUIName.Bag);
        UIManager.GetT.OpenUI(ShowUIName.Shop);
    }
}
