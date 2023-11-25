using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ApplicationData
    {
        public static Db_Lab4Entities1 db = new Db_Lab4Entities1();

        public recordNode GetById(int id)
        {
            return db.recordNode.FirstOrDefault(x => x.Id == id);
        }

        public recordNode GetByName(string name)
        {
            return db.recordNode.FirstOrDefault(x => x.Name == name);
        }

        public void AddRecord(string name, string messege)
        {
            recordNode recordNode1 = db.recordNode.FirstOrDefault(x => x.Name == name && x.Message == messege);
            if (recordNode1 == null)
            {
                recordNode recordNode = new recordNode();
                recordNode.Name = name;
                recordNode.Message = messege;
                db.recordNode.Add(recordNode);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine("Такой пользователь с такой записью уже есть!");
            }
        }

        public void UpdateRecord(int id, string messageUpdate)
        {
            recordNode recordNode = db.recordNode.FirstOrDefault(x => x.Id == id);
            recordNode.Message = messageUpdate;

            db.recordNode.AddOrUpdate(recordNode);
            db.SaveChanges();
        }

        public void RemoveRecord(int id)
        {
            recordNode recordNode = db.recordNode.FirstOrDefault(x => x.Id == id);
            db.recordNode.Remove(recordNode);
            db.SaveChanges();
        }
    }
}
