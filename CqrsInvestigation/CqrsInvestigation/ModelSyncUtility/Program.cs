using System;
using CqrsDal;
using CqrsDal.Contracts;
using CqrsDal.Tests;

namespace ModelSyncUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var queryRepository = new MongoRepository();
                var commandRepository = new ProductsRepository();
                IPushProductMessages messageDispatcher = new FakePushProductMessages();
                var synchronizer = new ModelSynchronizer(queryRepository, messageDispatcher);

                var products = commandRepository.FindAll();

                foreach (var product in products)
                {
                    synchronizer.UpdateQueryProduct(product);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Completed Model Synchronization");
        }
    }
}
