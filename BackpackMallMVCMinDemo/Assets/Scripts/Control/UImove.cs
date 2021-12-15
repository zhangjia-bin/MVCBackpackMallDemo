using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UImove : MonoBehaviour
{
    public Button shop;
    public Button bag;
    GameObject shop1;
    GameObject bag1;
    void Start()
    {
        bag1 = transform.Find("Bag(Clone)").gameObject;
        shop1 = transform.Find("Shop(Clone)").gameObject;
        shop.onClick.AddListener(()=> {

            
            if (shop1.transform.localPosition.y >= 3000)
            {
                shop1.transform.DOLocalMove(new Vector3(-400, 0, 0), 3);
            }else if (shop1.transform.localPosition.y <= 1)
            {
                shop1.transform.DOLocalMove(new Vector3(-400, 3100, 0), 3);
            }
        });
        bag.onClick.AddListener(() => {

            
            if (bag1.transform.localPosition.y >= 3000)
            {
                Debug.Log("222211");
                bag1.transform.DOLocalMove(new Vector3(450, 0, 0), 3);
            }
            else if (bag1.transform.localPosition.y <= 11)
            {
                Debug.Log("22222222");
                bag1.transform.DOLocalMove(new Vector3(450, 3100, 0), 3);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
