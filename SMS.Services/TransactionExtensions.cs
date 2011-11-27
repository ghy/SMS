using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace SMS.Services
{
    public static class TransactionExtensions
    {
        public static CustomerTransaction RequestTransaction(this ISession session)
        {
            var isActive = session.Transaction.IsActive;

            if (!isActive)
            {
                session.Transaction.Begin();
            }

            var customerTransaction = new CustomerTransaction
            {
                Transaction = session.Transaction,
                IsOwner = !isActive
            };

            return customerTransaction;
        }
    }

    public class CustomerTransaction : IDisposable
    {
        public ITransaction Transaction { get; set; }
        public bool IsOwner { get; set; }

        public void Dispose()
        {
            if (IsOwner)
            {
                Transaction.Dispose();
            }
        }

        public void Commit()
        {
            if (IsOwner)
            {
                Transaction.Commit();
            }
        }
    }
}
