//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevelopmentRepairEngine.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewMessage
    {
        public int NewMessageID { get; set; }
        public System.DateTime DateAndTime { get; set; }
        public int RequestID { get; set; }
        public string Descryption { get; set; }
        public int RequestStatusID { get; set; }
        public int UserID { get; set; }
    
        public virtual Request Request { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual User User { get; set; }
    }
}