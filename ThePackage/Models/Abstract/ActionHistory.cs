using System;

namespace ThePackage.Models.Abstract
{
    public abstract class ActionHistory
    {
        public DateTime DateInsert { get; private set; }

        public DateTime? DateUpdate { get; set; }

        public ActionHistory()
        {
            DateInsert = DateTime.UtcNow;
        }
    }
}
