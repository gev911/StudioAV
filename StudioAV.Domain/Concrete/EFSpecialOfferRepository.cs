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
                _context = new StudioAVEntities();
                return _context.SpecialOffers;

            }
        }


        public SpecialOffer Delete(int offerId)
        {
            using (_context = new StudioAVEntities())
            {
                SpecialOffer dbEntry = _context.SpecialOffers.Find(offerId);
                if (dbEntry != null)
                {
                    _context.SpecialOffers.Remove(dbEntry);
                    _context.SaveChanges();
                }

                return dbEntry;
            }
        }

        public bool Save(SpecialOffer offer)
        {
            using (_context = new StudioAVEntities())
            {
                try
                {
                    if (offer.Id == 0)
                    {
                        offer.DateCreated = DateTime.Now;
                        _context.SpecialOffers.Add(offer);
                    }
                    else
                    {
                        SpecialOffer dbEntry = _context.SpecialOffers.Find(offer.Id);
                        if (dbEntry != null)
                        {
                            dbEntry.Actual = offer.Actual;
                            dbEntry.Description = offer.Description;
                            dbEntry.Name = offer.Name;
                            dbEntry.URL = offer.URL;
                            dbEntry.BannerPath = offer.BannerPath;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
