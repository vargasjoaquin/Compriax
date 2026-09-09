using CompriaxSystem.Domain.Entities;
using CompriaxSystem.Domain.Enums;
using CompriaxSystem.Infrastructure.Persistence;
using CompriaxSystem.MercadoPago.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompriaxSystem.MercadoPago.Api.Services
{
    public class TransactionService(ApplicationDbContext context) : ITransactionService
    {
        public async Task<MercadoPagoTransaction> InitializeTransactionAsync(int saleId, decimal amount, string idempotencyKey)
        {
            var transaction = new MercadoPagoTransaction
            {
                SaleId = saleId,
                StatusId = (int)MercadoPagoPaymentStatus.Pending,
                Amount = amount,
                IdempotencyKey = idempotencyKey,
                CreatedAt = DateTime.UtcNow,
            };

            await context.MercadoPagoTransactions.AddAsync(transaction);
            await context.SaveChangesAsync();

            return transaction;
        }

        public async Task<MercadoPagoTransaction?> GetByIpempotencyKeyAsync(string idempotencyKey)
        {
            return await context.MercadoPagoTransactions
                .Include(t => t.Status)
                .FirstOrDefaultAsync(t => t.IdempotencyKey == idempotencyKey);
        }
        public async Task UpdateTransactionStatusAsync(string orderId, MercadoPagoPaymentStatus status, string? externalPaymentId = null)
        {
            var transaction = await context.MercadoPagoTransactions
                .FirstOrDefaultAsync(t => t.OrderId == orderId);

            if (transaction != null)
            {
                transaction.StatusId = (int)status;
                transaction.ExternalPaymentId = externalPaymentId;
                transaction.UpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> HasApprovedTransactionAsync(int saleId)
        {
            return await context.MercadoPagoTransactions
                .AnyAsync(t => t.SaleId == saleId && t.StatusId == (int)MercadoPagoPaymentStatus.Approved);
        }
    }
}
