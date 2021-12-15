using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ModelName
{
    ShopData,
        BuyPanelData,
        BagData
}

public class ModeManager :Singleton<ModeManager>
{
    Dictionary<ModelName, ModelBase> AllModel = new Dictionary<ModelName, ModelBase>();


    //加载所有数据model
    public void AllModelLoad()
    {
       ResModel(new ShopData());
       ResModel(new BagData());
        ResModel(new BuyPanelData());
    }
    //添加到字典当中
    public void ResModel(ModelBase modelBase)
    {
        if(!AllModel.ContainsValue(modelBase))
        {
            AllModel.Add(modelBase.modelName,modelBase);
            modelBase.Onload();
        }
    }

    //从中获取到字典里的model数据
    public ModelBase GetModel(ModelName modelName)
    {
        ModelBase model;
        AllModel.TryGetValue(modelName, out model);
        if (model != null)
        {
            return model;
        }
        return null;
    }
}
