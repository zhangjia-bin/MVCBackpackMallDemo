using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public DisplayType type;
    /// <summary>
    /// UI初始化，发生在UI资源实例化之后
    /// </summary>
    public virtual void Init() { }
    /// <summary>
    /// UI显示
    /// </summary>
    public virtual void Show() { this.gameObject.SetActive(true); }
    /// <summary>
    /// 隐藏
    /// </summary>
    public virtual void Hide() { this.gameObject.SetActive(false); }
    /// <summary>
    /// 恢复显示
    /// </summary>
    public virtual void ReDisplay() { this.gameObject.SetActive(true); }
}
