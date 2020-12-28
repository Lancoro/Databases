using System;
using System.Collections.Generic;

#nullable disable

namespace LehaLab3_1
{
    public partial class Leader
    {
        public Leader()
        {
            Companies = new HashSet<Company>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Company> Companies { get; set; }


        public class Leader_DIU
        {

            public static void Insert(int id, string name)
            {
                using (SiteContext db = new SiteContext())
                {
                    Leader newLeader = new Leader();
                    newLeader.Id = id;
                    newLeader.Name = name;
                    db.Leaders.Add(newLeader);
                    db.SaveChanges();

                }
            }

            public static void Update(int id, string name)
            {
                using (SiteContext db = new SiteContext)
                {
                    Leader leader = db.Leaders.Find(id);
                    leader.Name = name;
                    db.Leaders.Update(leader);
                    db.SaveChanges();

                }
            }


            public static void Delete(int id)
            {
                using(SiteContext db = new SiteContext())
                {
                    Leader leader = db.Leaders.Find(id);
                    db.Leaders.Remove(leader);
                    db.SaveChanges();
                }
            }

        }

    }
}
