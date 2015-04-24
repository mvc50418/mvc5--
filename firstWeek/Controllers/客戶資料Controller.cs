using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using firstWeek.Models;

namespace firstWeek.Controllers
{
    public class 客戶資料Controller : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();
        
        //TODO: 不同 controller 的 webTitle 要不一樣  但是 要在每個 action 裏面都加一句 ViewBag.message = webTitle 這樣很容易漏掉沒加，不知道有沒有更有效的寫法 

        string webTitle = "ASP.NET MVC 5 開發實戰 (台北) (2015/4/18 ~ 5/10)";
        // GET: 客戶資料
        public ActionResult Index()
        {
            ViewBag.message = webTitle;
            
            return View(db.客戶資料.Where(D=>D.是否已刪除==true).ToList());
        }
       
        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.message = webTitle; 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            ViewBag.message = webTitle; 

            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            ViewBag.message = webTitle; 

            if (ModelState.IsValid)
            {
                客戶資料.是否已刪除 = true;
                db.客戶資料.Add(客戶資料);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.message = webTitle; 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            ViewBag.message = webTitle; 

            if (ModelState.IsValid)
            {
                db.Entry(客戶資料).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.message = webTitle; 

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var 客戶資料 = db.客戶資料.Find(id);
            if (客戶資料 == null || 客戶資料.是否已刪除 == false)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.message = webTitle; 

            var  客戶資料 = db.客戶資料.Find(id);
            if (客戶資料!=null)
            {
                客戶資料.是否已刪除 = false;
            }
            //db.客戶資料.FirstOrDefault().是否已刪除 = true;
            //db.客戶資料.Remove(客戶資料);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //實作一份簡易報表，顯示欄位有「客戶名稱、聯絡人數量、銀行帳戶數量」共三個欄位，用一個表格呈現報表即可。

        public ActionResult Report()
        {
            ViewBag.message = webTitle;
            var query = db.客戶資料.ToList()
                .Select(c => new 客戶報表Viewmodel   //myViewmodel
                {
                    客戶名稱 = c.客戶名稱,
                    銀行數量 = c.客戶銀行資訊.Count,
                    聯絡人數量 = c.客戶聯絡人.Count
                });

            return View(query);
        }

        //用  view 做報表
        public ActionResult Report_view()
        {
            ViewBag.message = webTitle;

            return View(db.View_客戶報表.ToList());
            
        }



    }
}
