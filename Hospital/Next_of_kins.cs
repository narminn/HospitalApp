//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital
{
    using System;
    using System.Collections.Generic;
    
    public partial class Next_of_kins
    {
        public int Id { get; set; }
        public string Kin_fullname { get; set; }
        public string Kin_gender { get; set; }
        public int Kin_stateof_origin_id { get; set; }
        public string Kin_phone { get; set; }
        public string Kin_address { get; set; }
        public string Kin_relation_of_patient { get; set; }
    
        public virtual State_of_origins State_of_origins { get; set; }
    }
}
