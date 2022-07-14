using FruitStore.OrderCloud.Common.Models.Xp;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.OrderCloud.Common.Models.FSBuyerProduct
{

    public class FSBuyerProduct : BuyerProduct
    {
        /// <summary>
        /// The Image details of Products are stored in the Extended Properties
        /// </summary>
        public new ImageXp xp
        {
            get
            {
                return GetProp<ImageXp>("image");
            }
            set
            {
                SetProp("image", value);
            }
        }
    }
}
