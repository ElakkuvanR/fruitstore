using FruitStore.OrderCloud.Common.Models.Base;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.OrderCloud.Common.Models
{
    public class SuperOCProduct : IOCObject
    {
        public string ID { get; set; }
        public OCProduct Product { get; set; }
        public IList<OCVariant> Variants { get; set; }
    }
    public class OCProduct : Product<ProductXp>, IOCObject
    {

    }
    public class OCVariant : Variant<OCVariantXp>
    {
    }
    public class OCVariantXp
    {
        public string SpecCombo { get; set; }

        public List<OCSpecValue> SpecValues { get; set; }

        public string NewID { get; set; }

        public List<ImageAsset> Images { get; set; }
    }
    public class OCSpecValue
    {
        public string SpecName { get; set; }

        public string SpecOptionValue { get; set; }

        public string PriceMarkup { get; set; }
    }
    public class ImageAsset
    {
        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }

        public List<string> Tags { get; set; }
    }
}
