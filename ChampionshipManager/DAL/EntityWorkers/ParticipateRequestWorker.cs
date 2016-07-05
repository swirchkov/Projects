using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityWorkers
{
    internal class ParticipateRequestWorker : EntityWorker, IEntityWorker<ParticipateRequest>
    {
        public void Create(ParticipateRequest item)
        {
            db.ParticipateRequests.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            ParticipateRequest item = db.ParticipateRequests.FirstOrDefault(req => req.Id == id);

            if (item == null)
            {
                throw new ArgumentException();
            }

            db.ParticipateRequests.Remove(item);
            db.SaveChanges();
        }

        public IEnumerable<ParticipateRequest> Find(Func<ParticipateRequest, bool> predicate)
        {
            return db.ParticipateRequests.Where(predicate);
        }

        public ParticipateRequest Get(int id)
        {
            return db.ParticipateRequests.FirstOrDefault(req => req.Id == id);
        }

        public void Update(ParticipateRequest item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
