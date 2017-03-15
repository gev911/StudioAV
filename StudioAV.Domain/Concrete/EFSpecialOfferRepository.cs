using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudioAV.Domain.Abstract;

namespace StudioAV.Domain.Concrete
{
    public class EFSpecialOfferRepository : ISpecialOfferRepository
    {
        private StudioAVEntities _context;

        //private StudioAVEntities _context = new StudioAVEntities();

        public IEnumerable<SpecialOffer> SpecialOffers
        {
            get
            {
                using (_context = new StudioAVEntities())
                {
                    return _context.SpecialOffers;
                }
            }
        }


        public SpecialOffer Delete(int offerId)
        {
            using(_context = new StudioAVEntities())
            {
                SpecialOffer DbEntry = _context.SpecialOffers.Find(offerId);
                if(DbEntry != null)
                {
                    _context.SpecialOffers.Remove(DbEntry);
                    _context.SaveChanges();
                }

                return DbEntry;
            }
        }

        public bool Save(SpecialOffer offer)
        {
            using (_context = new StudioAVEntities())
            {
                try
                {
                    if(offer.Id == 0)
                    {
                        offer.DateCreated = DateTime.Now;
                        _context.SpecialOffers.Add(offer);
                    }
                    else
                    {
                        SpecialOffer dbEntry = _context.SpecialOffers.Find(offer.Id);
                        if(dbEntry != null)
                        {
                            dbEntry.Actual = offer.Actual;
                            dbEntry.Description = offer.Description;
                            dbEntry.ImageData = offer.ImageData;
                            dbEntry.ImageType = offer.ImageType;
                            dbEntry.Name = offer.Name;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    _context.SaveChanges();
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
        }
    }
}
