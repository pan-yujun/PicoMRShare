using UnityEngine;
using System.Collections.Generic;

namespace GF.SimpleUIKit
{
    public interface ISelectable
    {
        SingleSelector SingleSelector { get; set; }

        void Select();

        void Deselect();
    }

    /// <summary>
    /// 单项选择器
    /// 功能：在一组可选择的对象中选中其中一个，上一个取消选中
    /// </summary>
    public class SingleSelector
    {
        private List<ISelectable> itemList = new List<ISelectable>();

        public ISelectable curSelect;

        public SingleSelector(params ISelectable[] itemArr)
        {
            for (int i = 0; i < itemArr.Length; i++)
            {
                AddItem(itemArr[i]);
            }
        }

        /// <summary>
        /// 重置状态
        /// </summary>
        public void ResetState()
        {
            foreach (var item in itemList)
            {
                item.Deselect();
            }
        }

        public void AddItem(ISelectable itemToAdd)
        {
            itemToAdd.SingleSelector = this;

            itemList.Add(itemToAdd);
        }

        public void RemoveItem(ISelectable itemTomove)
        {
            itemTomove.SingleSelector = null;

            itemTomove.Deselect();

            itemList.Remove(itemTomove);
        }

        public void SelectItem(ISelectable itemToSelect)
        {
            if (curSelect != null&& curSelect!=itemToSelect)
                curSelect.Deselect();

            itemToSelect.Select();

            curSelect = itemToSelect;
        }
    }
}
