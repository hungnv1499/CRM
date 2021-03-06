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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderItems = new HashSet<OrderItem>();
            this.ProductAttributeMappings = new HashSet<ProductAttributeMapping>();
            this.ProductPictureMappings = new HashSet<ProductPictureMapping>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public int OldPrice { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string NameEng { get; set; }
        public string DescEng { get; set; }
        public string ContentEng { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime LastEditedTime { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsHomePage { get; set; }
        public bool IsPublic { get; set; }
        public bool Deleted { get; set; }
        public int Position { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductAttributeMapping> ProductAttributeMappings { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPictureMapping> ProductPictureMappings { get; set; }
    }
}
