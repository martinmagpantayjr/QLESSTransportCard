using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.QLESSTransport.BL.MrtFareService;
using API.QLESSTransport.Models.Enums;
using Microsoft.EntityFrameworkCore;
using QLESSTransport.DAL;
using QLESSTransport.Models;

namespace API.QLESSTransport.BL.TransportCardService
{
    public class TransportCardService : ITransportCardService
    {
        private readonly int _maxLoadAmount = 10000;
        private readonly int _initialLoadAmount = 100;
        private readonly int _maximumRegularDiscountCount = 4;
        private readonly Regex _pwdIdFormat = new Regex("^\\d{2}-\\d{4}-\\d{4}");
        private readonly Regex _seniorIdFormat = new Regex("^\\d{4}-\\d{4}-\\d{4}");
        private readonly QLESSContext _context;
        private readonly IMrtFareService _mrtFareService;

        public TransportCardService(QLESSContext context, IMrtFareService mrtFareService)
        {
            _context = context;
            _mrtFareService = mrtFareService;
        }
        public async Task<TransportCard> GetTransportCardById(int id)
        {
            if (id == 0) return null;

            var transportCard = await _context.TransportCards.FirstOrDefaultAsync(f => f.Id == id);

            return transportCard;
        }

        public async Task<IEnumerable<TransportCard>> GetTransportCards()
        {
            var transportCards = await _context.TransportCards.ToListAsync();

            return transportCards;
        }

        public async Task<double> AddLoad(int id, int load)
        {
            var transportCard = await GetCardDetailById(id);

            var totalLoad = transportCard.Load + load;

            if (totalLoad > _maxLoadAmount)
            {
                throw new Exception("Max Load Amount Exceeded");
            }

            transportCard.Load += load;

            if (await _context.SaveChangesAsync() <= 0) {
                throw new Exception("Adding load amount failed.");
            }

            return transportCard.Load;
        }

        public async Task<int> PurchaseTransportCard(int load)
        {
            if (load < _initialLoadAmount || load > _maxLoadAmount)
            {
                throw new Exception($"Initial load must be {_initialLoadAmount} or higher but less than {_maxLoadAmount}");
            }

            var transportCard = new TransportCard
            {
                Load = load
            };

            _context.Add(transportCard);

            if (await _context.SaveChangesAsync() <= 0)
            {
                throw new Exception("Purchasing card failed");
            }

            return transportCard.Id;
        }

        public async Task<bool> RegisterTransportCard(int id, DiscountRegistrationTypeEnum discountType, string discountId)
        {
            var transportCard = await GetCardDetailById(id);

            if (!string.IsNullOrWhiteSpace(transportCard.DiscountId))
            {
                throw new Exception("Card has already been registered");
            }

            if (transportCard.PurchaseDate.AddMonths(6) < new DateTime())
            {
                throw new Exception("Card already passed the qualified registration date. Card should be registered not later than 6 months upon purchase.");
            }

            var cardFromDiscountId = await _context.TransportCards.FirstOrDefaultAsync(t => t.DiscountId == discountId);

            if (cardFromDiscountId != null)
            {
                throw new Exception("PWD or Senior ID presented is already in used.");
            }

            if (discountType == DiscountRegistrationTypeEnum.PWD)
            {
                if (!_pwdIdFormat.IsMatch(discountId))
                {
                    throw new Exception("Invalid PWD ID Format");
                }
            }
            else
            {
                if (!_seniorIdFormat.IsMatch(discountId))
                {
                    throw new Exception("Invalid Senior ID Format");
                }
            }

            transportCard.DiscountRegistrationType = discountType;
            transportCard.DiscountId = discountId;

            return await _context.SaveChangesAsync() > 0 ? true : throw new Exception("Registration failed");
        }

        public async Task<double> PayFare(int id, string fromLocation, string toLocation)
        {
            var transportCard = await GetCardDetailById(id);

            var fareDetail = await _mrtFareService.GetMrtFareByLocation(fromLocation, toLocation);

            if (fareDetail == null)
            {
                throw new Exception("Fare details cannot found");
            }

            double fareAfterDiscount = fareDetail.Fare;

            if (transportCard.DiscountAppliedCount <= _maximumRegularDiscountCount)
            {
                transportCard.DiscountAppliedCount++;
                fareAfterDiscount = fareDetail.Fare - (fareDetail.Fare * .03);
            } 
            else if (transportCard.LastUsedDate.HasValue && new DateTime().Date > transportCard.LastUsedDate.Value.Date)
            {
                transportCard.DiscountAppliedCount = 1;
                fareAfterDiscount = fareDetail.Fare - (fareDetail.Fare * .03);
            }

            if (transportCard.TransportCardType == TransportCardTypeEnum.Discounted)
            { // To use for PWD and Senior checking
                fareAfterDiscount = fareAfterDiscount - (fareAfterDiscount * .2);
            }

            if (transportCard.Load < fareAfterDiscount)
            {
                throw new Exception("Insufficient balance");
            }

            transportCard.Load -= fareAfterDiscount;
            transportCard.LastUsedDate = new DateTime();

            if (await _context.SaveChangesAsync() <= 0)
            {
                throw new Exception("Payment failed");
            }

            return transportCard.Load;
        }

        public async Task<double> GetCardBalance(int id)
        {
            var transportCard = await GetCardDetailById(id);

            return transportCard.Load;
        }

        private async Task<TransportCard> GetCardDetailById(int id)
        {
            if (id == 0)
            {
                throw new Exception("Invalid Id");
            }

            var transportCard = await _context.TransportCards.FirstOrDefaultAsync(f => f.Id == id);

            if (transportCard == null)
            {
                throw new Exception("Card cannot found");
            }

            return transportCard;
        }
    }
}