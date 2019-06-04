using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labixa.Areas.Admin.ViewModel.WebsiteAtribute
{
    public class WebsiteAttributeFormModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName(@"Tên thuộc tính")]
        public string Name { get; set; }

        [DisplayName(@"Mô tả")]
        public string Description { get; set; }

        [DisplayName(@"Giá trị")]
        public string Value { get; set; }

        [DisplayName(@"Cách điều khiển")]
        public string ControlType { get; set; }
        [DisplayName(@"Dạng")]
        public string Type { get; set; }

        [DisplayName(@"Công bố")]
        public bool IsPublic { get; set; }
    }
}