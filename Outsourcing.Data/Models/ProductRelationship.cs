//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Outsourcing.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductRelationship
    {
        public int Id { get; set; }
        public int ProductRelateId { get; set; }
        public int ProductId { get; set; }
        public bool isAvailable { get; set; }
    }
}
