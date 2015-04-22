using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace firstWeek.Models
{
    public class 客戶報表Viewmodel
    {
        public int Id { get; set; }
        public string 客戶名稱 { get; set; }
        public string 統一編號 { get; set; }
        public string 電話 { get; set; }
        public string 傳真 { get; set; }
        public string 地址 { get; set; }
        public string Email { get; set; }
        public int 聯絡人數量 { get; set; }
        public int 銀行數量 { get; set; }


        public virtual ICollection<客戶銀行資訊> 客戶銀行資訊 { get; set; }
        public virtual ICollection<客戶聯絡人> 客戶聯絡人 { get; set; }
    }
}