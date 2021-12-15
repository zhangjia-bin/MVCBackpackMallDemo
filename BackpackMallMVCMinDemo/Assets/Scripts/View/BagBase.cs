using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BagBase : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform part;//临时父节点
    Canvas root;
    Image item;

    #region 属性与字段
    //唯一的Id
    private int id = -1;

    int xb;//唯一的下标
    public int Id { get => id; set => id = value; }
    public int Xb { get => xb; set => xb = value; }

    #endregion


    public void OnBeginDrag(PointerEventData eventData)
    {
        //透明度
        //item.DOFade(0,3f);
        root = transform.root.GetComponent<Canvas>();
        part = transform.parent.transform.parent.transform.parent;
        item.transform.SetParent(part);
        //关闭射线投射效果
        item.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        item.transform.position = Input.mousePosition;
        Debug.Log("11111111::::"+item.transform.position);
        Debug.Log("22222222::::"+item.transform.localPosition);
        //Vector2 pos;
        //if (RectTransformUtility.ScreenPointToLocalPointInRectangle(part as RectTransform,Input.mousePosition,root.worldCamera,out pos))
        //{
        //    item.transform.localPosition = pos;
        //}
        
    }
    BagData items;

    //拖拽的使用！！
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Id == -1 || Id < 0) return;
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            item.transform.localPosition = Vector3.zero;
        }
        else if (eventData.pointerCurrentRaycast.gameObject.CompareTag("BagGrid"))
        {
            items = ModeManager.GetT.GetModel(ModelName.BagData) as BagData;
            int startid = eventData.pointerCurrentRaycast.gameObject.transform.parent.GetComponent<BagBase>().xb;


            //int index=0;
            //int index1=0;
            //for (int i = 0; i < items.Items.Count; i++)
            //{
            //    if (items.Items[i].Id == startid)
            //    {
            //        index = i;
            //    }
            //}
            //for (int i = 0; i < items.Items.Count; i++)
            //{
            //    if (items.Items[i].Id == id)
            //    {
            //        index1 = i;
            //    }
            //}


            //数据交换（通过下标交换数据）
            ItemData ss = items.Items[startid];
            items.Items[startid] = items.Items[xb];
            items.Items[xb] = ss;

            //更新背包数据
            MessageManager.GetT.OnSend(1002);
            item.transform.localPosition = Vector3.zero;
        }
        //开启射线投射效果
        //回到一开始最初的父节点
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
        item.raycastTarget = true;

        
    }

   

    private void Awake()
    {
        item=  transform.Find("Item").GetComponent<Image>();
    }
    

   
    //这句话暂时没有用处！！！
    public void UpdataPanel()
    {
        if (Id == -1) return;
        items = ModeManager.GetT.GetModel(ModelName.BagData) as BagData;
        item.sprite = Resources.Load<Sprite>("Arts/" + Id);
        transform.Find("Item").GetComponentInChildren<Text>().text = "数量" + items.Items[Id].Max + "/价格：" + items.Items[Id].Price;
        item.transform.localPosition = Vector3.zero;
    }

   
}
