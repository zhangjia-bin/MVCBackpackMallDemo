using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagUI : UIBase
{
    public GameObject Conten;
    public Button Zl;
    
    public override void Init()
    {
        base.Init();
        MessageManager.GetT.OnAddliston(1002,UpdataPanel);
        MessageManager.GetT.OnSend(1002);
        Zl.onClick.AddListener(ClearUp);
        (Zl.transform as RectTransform).sizeDelta = new Vector2(320,30);
    }

    private void ClearUp()
    {
        items.Items.Sort(SortItms);
        MessageManager.GetT.OnSend(1002);
    }

    //背包整理方法！！！
    //底层是冒泡排序
    int  SortItms(ItemData a,ItemData b)
    {
        

        if (a.Id>b.Id)
        {
            return 1;
        }
        else if(a.Id<b.Id)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }


    BagData items;
    List<GameObject> list = new List<GameObject>();
    private void UpdataPanel(object obj)
    {
        //先清空原先原有数据
        for (int i = 0; i < list.Count; i++)
        {
            Destroy(list[i].gameObject);
        }
        list.Clear();

        //重新对背包进行更新
        //获取背包数据！！！！
        items = ModeManager.GetT.GetModel(ModelName.BagData) as BagData;

        for (int i = 0; i < items.Items.Count; i++)
        {
            //格子预制体
            GameObject go = Instantiate(Resources.Load<GameObject>("Grid"));


            go.transform.Find("Item").GetComponent<Image>().sprite=Resources.Load<Sprite>("Arts/"+items.Items[i].Id);

            //显示数据的id
            go.GetComponent<BagBase>().Id = items.Items[i].Id;

            //利用唯一的下标换数据
            go.GetComponent<BagBase>().Xb = i;
            go.transform.Find("Item").GetComponentInChildren<Text>().text = "数量" + items.Items[i].Max + "/价格：" + items.Items[i].Price;
            //设为父类显示
            go.transform.SetParent(Conten.transform);
            list.Add(go);
        }
    }

    public override void Show()
    {
        base.Show();
        MessageManager.GetT.OnSend(1002);
    }
    public override void ReDisplay()
    {
        base.ReDisplay();
    }
    public override void Hide()
    {
        base.Hide();
    }
    
}
