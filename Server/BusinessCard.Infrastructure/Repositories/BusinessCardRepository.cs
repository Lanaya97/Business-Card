using BusinessCard.Application.Interfaces;
using BusinessCard.Infrastructure.Abstraction;
using BusinessCard.Infrastructure.DatabaseContext;
using System;

namespace BusinessCard.Infrastructure.Repositories
{
    public class BusinessCardRepository : Repository<Domain.BusinessCard>, IBusinessCardRepository
    {
        public BusinessCardRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
