using DoNotBuyThisApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DoNotBuyThisApp.Data.Models
{
    public partial class Constant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? NumericValue { get; set; }
        public string LiteralValue { get; set; }
        public int ValueType { get; set; }

        [NotMapped]
        public ConstantTypes Type
        {
            get => (ConstantTypes)ValueType;
            set => ValueType = (int)value;
        }
    }
}
