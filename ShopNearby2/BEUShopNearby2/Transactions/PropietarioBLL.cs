﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUShopNearby2.Transactions
{
    public class PropietarioBLL
    {
        public static void Create(Propietario a)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Propietario.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Propietario Get(int? id)
        {
            Entities db = new Entities();
            return db.Propietario.Find(id);
        }

        public static void Update(Propietario Propietario)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Propietario.Attach(Propietario);
                        db.Entry(Propietario).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Propietario Propietario = db.Propietario.Find(id);
                        db.Entry(Propietario).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public static List<Propietario> List()
        {
            Entities db = new Entities();
            return db.Propietario.ToList();
        }
    }
}

