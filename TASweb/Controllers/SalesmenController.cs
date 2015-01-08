using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TASweb.Models;

namespace TASweb.Controllers
{
    public class SalesmenController : Controller
    {
        private TASEntities db = new TASEntities();
        private const string AuthToken = "HRpIjHRpIj120iKN";
        private const string pass_phrase = "Tong888Neat421";
        private const int key_size = 64;
        // GET: Salesmen
        public ActionResult Index()
        {
            var salesmen = db.Salesmen.Include(s => s.Company).Include(s => s.Terminal);
            return View(salesmen.ToList());
        }

        // GET: Salesmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // GET: Salesmen/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            ViewBag.AssignedTerminal = new SelectList(db.Terminals, "TerminalID", "UUID");
            return View();
        }

        // POST: Salesmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesmanID,CompanyID,UserName,Password,FirstName,LastName,AssignedTerminal,Status")] Salesman salesman)
        {
            if (ModelState.IsValid)
            {
                string encrypted_pass = EncryptThis(salesman.Password);
                salesman.Password = encrypted_pass;
                db.Salesmen.Add(salesman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", salesman.CompanyID);
            ViewBag.AssignedTerminal = new SelectList(db.Terminals, "TerminalID", "UUID", salesman.AssignedTerminal);
            return View(salesman);
        }

        // GET: Salesmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", salesman.CompanyID);
            ViewBag.AssignedTerminal = new SelectList(db.Terminals, "TerminalID", "UUID", salesman.AssignedTerminal);
            return View(salesman);
        }

        // POST: Salesmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesmanID,CompanyID,UserName,Password,FirstName,LastName,AssignedTerminal,Status")] Salesman salesman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", salesman.CompanyID);
            ViewBag.AssignedTerminal = new SelectList(db.Terminals, "TerminalID", "UUID", salesman.AssignedTerminal);
            return View(salesman);
        }

        // GET: Salesmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salesman salesman = db.Salesmen.Find(id);
            if (salesman == null)
            {
                return HttpNotFound();
            }
            return View(salesman);
        }

        // POST: Salesmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salesman salesman = db.Salesmen.Find(id);
            db.Salesmen.Remove(salesman);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string EncryptThis(string plain_text)
        {
            byte[] init_vector_bytes = Encoding.UTF8.GetBytes(AuthToken);
            byte[] plain_text_bytes = Encoding.UTF8.GetBytes(plain_text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(pass_phrase, null);
            byte[] key_bytes = password.GetBytes(key_size / 8);
            RijndaelManaged symmetric_key = new RijndaelManaged();
            symmetric_key.Mode = CipherMode.CBC;
            symmetric_key.Padding = PaddingMode.PKCS7;
            ICryptoTransform encryptor = symmetric_key.CreateEncryptor(key_bytes, init_vector_bytes);
            MemoryStream memory_stream = new MemoryStream();
            CryptoStream crypto_stream = new CryptoStream(memory_stream, encryptor, CryptoStreamMode.Write);
            crypto_stream.Write(plain_text_bytes, 0, plain_text_bytes.Length);
            crypto_stream.FlushFinalBlock();
            byte[] cipher_text_bytes = memory_stream.ToArray();
            memory_stream.Close();
            crypto_stream.Close();
            return Convert.ToBase64String(cipher_text_bytes);
        }

        public string DecryptThis(string cipher_text)
        {
            byte[] init_vector_bytes = Encoding.UTF8.GetBytes(AuthToken);
            byte[] cipher_text_bytes = Encoding.UTF8.GetBytes(cipher_text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(pass_phrase, null);
            byte[] key_bytes = password.GetBytes(key_size / 8);
            RijndaelManaged symmetric_key = new RijndaelManaged();
            symmetric_key.Mode = CipherMode.CBC;
            symmetric_key.Padding = PaddingMode.PKCS7;
            ICryptoTransform decryptor = symmetric_key.CreateDecryptor(key_bytes, init_vector_bytes);
            MemoryStream memory_stream = new MemoryStream();
            CryptoStream crypto_stream = new CryptoStream(memory_stream, decryptor, CryptoStreamMode.Read);
            byte[] plain_text_bytes = new byte[cipher_text_bytes.Length];
            int decrypted_byte_count = crypto_stream.Read(plain_text_bytes, 0, plain_text_bytes.Length);
            memory_stream.Close();
            crypto_stream.Close();
            return Encoding.UTF8.GetString(plain_text_bytes, 0, decrypted_byte_count);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
