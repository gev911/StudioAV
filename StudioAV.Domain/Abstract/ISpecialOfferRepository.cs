using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioAV.Domain.Abstract
{
    public interface ISpecialOfferRepository
    {
        IEnumerable<SpecialOffer> SpecialOffers { get; }

        bool Save(SpecialOffer offer);

        SpecialOffer Delete(int offerId);
    }
}
