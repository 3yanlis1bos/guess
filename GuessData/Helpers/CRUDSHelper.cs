using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuessData;

namespace GuessData.Helpers
{
    public class CRUDSHelper
    {
        public static void AddNewSuccess(int id) 
        {
            using (var db = new GuessEntities())
            {
                People p = db.People.Find(id);
                db.Statistics.Add(new Statistics()
                {
                    Date = DateTime.Now,
                    PeopleId = id
                });
            }
        }

        public static int GetSuccessCount()
        {
            using (var db = new GuessEntities())
            {
                return db.Statistics.Count();
            }
        }
    }
}
