//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSourceControls.TodosManager
{
    using System;
    using System.Collections.Generic;
    
    public partial class Todo
    {
        public System.Guid Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public System.Guid CategoryId { get; set; }
        public System.DateTime LastChange { get; set; }
    
        public virtual Category Category { get; set; }
    }
}