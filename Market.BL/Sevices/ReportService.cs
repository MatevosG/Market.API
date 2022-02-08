using Market.BL.Contracts;
using Market.DAL.Contracts;
using Market.DAL.Models;
using Market.DAL.Repositories;
using System;
using System.Linq;


namespace Market.BL.Sevices
{
    public class ReportService : IReportService
    {
        ITransactinRepository _transactinRepository;
        ITransactionItemRepository _transactionItemRepository;
        IProductRepository _productRepository;
        public ReportService(ITransactinRepository transactinRepository, ITransactionItemRepository transactionItemRepository, IProductRepository productRepository)
        {
            _transactinRepository = transactinRepository;
            _transactionItemRepository = transactionItemRepository;
            _productRepository = productRepository;
        }
        public ReportModel GetGroupedReport(DateTime startTime, DateTime endTime)
        {
            ReportModel result = new ReportModel();

            var reportFromDb = GetReport(startTime, endTime);
            result.StartTime = reportFromDb.StartTime;
            result.EndTime = reportFromDb.EndTime;
            result.Summary = reportFromDb.Summary;

            foreach (var product in reportFromDb.Products)
            {
                var productInResult = result.Products.FirstOrDefault(x => string.Equals(x.ProductName, product.ProductName));
                if (productInResult == null)
                {
                    ReportInfoModel reportInfo = new ReportInfoModel();
                    reportInfo.ProductName = product.ProductName;
                    reportInfo.ProductPrice = product.ProductPrice;
                    reportInfo.ProductCount = product.ProductCount;
                    result.Products.Add(reportInfo);
                }
                else
                {
                    productInResult.ProductCount += product.ProductCount;
                    productInResult.ProductPrice += product.ProductPrice;
                }

            }
            return result;
        }

        public ReportModel GetReport(DateTime startTime, DateTime endTime)
        {
            double summary = 0;
            var transactions = _transactinRepository.Get().Where(x => x.CreationTime >= startTime && x.CreationTime <= endTime);
            ReportModel reportModel = new ReportModel();
            reportModel.StartTime = startTime;
            reportModel.EndTime = endTime;

            foreach (var transaction in transactions)
            {

                var transactionItems = _transactionItemRepository.Get().Where(x => x.TransactionId == transaction.Id);

                foreach (var transactionItem in transactionItems)
                {

                    double itemSummary = transactionItem.Price;
                    summary += itemSummary;
                    var praduct = _productRepository.Get().FirstOrDefault(x => x.Id == transactionItem.ProductId);

                    if (praduct != null)
                    {
                        ReportInfoModel productModel = new ReportInfoModel();
                        productModel.ProductName = praduct.Name;
                        productModel.ProductPrice = transactionItem.Price;
                        productModel.ProductCount = transactionItem.ProductCount;
                        reportModel.Products.Add(productModel);
                    }
                }
            }
            reportModel.Summary = summary;
            return reportModel;
        }
    }
}
