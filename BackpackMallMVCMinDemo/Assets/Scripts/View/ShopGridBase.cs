using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class ShopGridBase : MonoBehaviour
{
    int id = -1;
    private Button button;
    private Text text;
    private void Awake()
    {
        init();


    }

    private void init()
    {
        //获取每个格子的商品数据
        button=GetComponent<Button>();
        text = GetComponentInChildren<Text>();
        button.onClick.AddListener(BuyPanel);
        //Destroy(button.GetComponent<Button>());
        //移除组建
    }


    /// <summary>
    /// 购买东西的面板
    /// </summary>
    ///
    //通过ModelManager获取ShopData的数据进行传送给显示面板
    ShopData model;
    BuyPanelData buyPanel;
    private void BuyPanel()
    {
        if (id == -1 || id < 0) return;
        //获取到商城库里面的数据
      model=  ModeManager.GetT.GetModel(ModelName.ShopData) as ShopData;

        //获取到显示面板的数据层
      buyPanel=  ModeManager.GetT.GetModel(ModelName.BuyPanelData) as BuyPanelData;

        //修改面板里面的数据
       buyPanel.ChangeData( model.GetItems(id));
    }

    public void UpdatePanel(ItemData data)
    {
        id = data.Id;
        if (id == -1 || id < 0) return;

        //如果存在数据就进行赋值
        button.GetComponent<Image>().sprite = Resources.Load<Sprite>("Arts/"+data.Id.ToString());
        text.text = "价格：" + data.Price + "/容量：" + data.Max;
    }

}
