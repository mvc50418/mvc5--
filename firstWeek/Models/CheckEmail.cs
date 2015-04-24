using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace firstWeek.Models
{
    public class CheckEmail : ValidationAttribute
    {

       
            public override bool IsValid(object value)
            {
                 客戶資料Entities db = new 客戶資料Entities();
                 var data = db.客戶資料.Where(D => D.Email == value && D.是否已刪除==true).Any();
                 if (data)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
                ////not input
                ////if (value == null)
                //    return true;
                ////has input
                //if (value is String)
                //    //手機應該都是開頭，並且有10碼，所以利用正則表示式來表示就是這樣
                //    //IsMatch本身就是bool的回傳值，所以利用直接回傳這個值，就可以表示是否已經通過驗證
                //    return Regex.IsMatch(value.ToString(), "^09[0-9]{8}");
                //else
                //    return true;
            }
       

    }
}