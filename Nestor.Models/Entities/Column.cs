//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nestor.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Column
    {
        public Column()
        {
            this.Articles = new HashSet<Article>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public bool ShowTop { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
        public int ParentId { get; set; }
        public string Link { get; set; }
    
        public virtual ICollection<Article> Articles { get; set; }
    }
}
