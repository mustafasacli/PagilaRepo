using Pagila.Command.Actor;
using Pagila.Command.Base.Result;
using Pagila.Query.Actor;
using SI.CommandBus;
using SI.CommandBus.Core;
using SI.QueryBus;
using SI.QueryBus.Core;
using System;
using System.Threading;

namespace Pagila.CommandHandlers.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICommandBus commandBus = new CommandBus();
            IQueryBus queryBus = new QueryBus();
            var cmd = new ActorInsertCommand
            {
                FirstName = "Mst",
                LastName = "Scl"
            };

            var result = commandBus.Send<ActorInsertCommand, LongCommandResult>(cmd);
            var response = queryBus.Send<ActorReadAllQuery, ActorList>(new ActorReadAllQuery());
            //var serviceDetailTypeHandler = new ServiceDetailTypeInsertCommandHandler();

            //var result = serviceDetailTypeHandler.Handle(cmd);
            var id = result.Data.ReturnValue ?? -1L;
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Thread.Sleep(2000);
            //var updateHandler = new ServiceDetailTypeUpdateCommandHandler();
            //result = updateHandler.Handle(
            //    new ServiceDetailTypeUpdateCommand
            //    {
            //        Id = id,
            //        DetailTypeName = "My First Service Updated",
            //        UpdatedBy = 1
            //    });
            result = commandBus.Send<ActorUpdateCommand, LongCommandResult>(new ActorUpdateCommand
            {
                FirstName = "Mst Updated",
                LastName = "Scl Updated",
                ActorId = (int)id
            });
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Thread.Sleep(2000);
            //var deleteHandler = new ServiceDetailTypeDeleteCommandHandler();
            //result = deleteHandler.Handle(
            //    new ServiceDetailTypeDeleteCommand
            //    {
            //        Id = id
            //    });
            result = commandBus.Send<ActorDeleteCommand, LongCommandResult>(new ActorDeleteCommand
            {
                Id = (int)id
            });
            Console.WriteLine("ReturnValue: " + result.Data?.ReturnValue);
            Console.WriteLine("ResponseCode: " + result.ResponseCode);
            Console.WriteLine("ResponseMessage: " + result.ResponseMessage);
            Console.ReadKey();
        }
    }
}
