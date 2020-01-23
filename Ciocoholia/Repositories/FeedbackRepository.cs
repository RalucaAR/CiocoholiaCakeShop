using CakeShop.Repositories;
using Ciocoholia.IRepositories;
using Ciocoholia.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciocoholia.Repositories
{
   public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {

        }
    }
}
