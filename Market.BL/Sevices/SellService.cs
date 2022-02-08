using Market.BL.Contracts;
using Market.DAL.Contracts;
using Market.DAL.Entities;
using Market.DAL.Models;
using Market.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Market.BL.Sevices
{
    public class SellService : ISellService
    {
        ITransactinRepository _transactinRepository;
        ITransactionItemRepository _transactionItemRepository;
        IProductRepository _productRepository;
        public SellService(IProductRepository productRepository, ITransactionItemRepository transactionItemRepository, ITransactinRepository transactinRepository)
        {
            _transactinRepository = transactinRepository;
            _transactionItemRepository = transactionItemRepository;
            _productRepository = productRepository;
        }
        public bool Sell(OparationModel model)
        {
            bool res = false;
            var transaction = _transactinRepository.Add(new Transaction { CreationTime = DateTime.UtcNow });
            foreach (var operation in model.Operations)
            {
                var tempProduct = _productRepository.Get(operation.ProductId);
                if (tempProduct == null || tempProduct.Count < operation.ProductCount)
                {
                    return res;
                }
                tempProduct.Count = tempProduct.Count - operation.ProductCount;
                 _productRepository.Update(tempProduct);

                _transactionItemRepository.Add(new TransactionItem
                {
                    Price = operation.ProductCount * tempProduct.Price,
                    ProductCount = operation.ProductCount,
                    ProductId = operation.ProductId,
                    TransactionId = transaction.Id
                });
            }
            res = true;
            return res;
        }
    }
}
