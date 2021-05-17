﻿using Coddie.Crud;
using Coddie.Data;
using Pagila.Command.Address;
using Pagila.Command.Base.Result;
using Pagila.Entity;
using SimpleInfra.Common.Response;
using System;

namespace Pagila.CommandHandlers.Address
{
    public class AddressDeleteCommandHandler : PagilaBaseCommandHandler<AddressDeleteCommand, LongCommandResult>
    {
        public override SimpleResponse<LongCommandResult> Handle(AddressDeleteCommand command)
        {
            var response = new SimpleResponse<LongCommandResult>();

            try
            {
                using (var connection = GetDbConnection())
                {
                    try
                    {
                        connection.OpenIfNot();
                        var result = connection.DeleteAll<AddressEntity>(p => p.AddressId == command.Id);
                        response.ResponseCode = result;
                        response.RCode = result.ToString();
                        response.Data = new LongCommandResult { ReturnValue = command.Id };
                    }
                    finally
                    {
                        connection.CloseIfNot();
                    }
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = -500;
                DayLogger.Error(ex);
            }

            return response;
        }

        public override SimpleResponse Validate(AddressDeleteCommand command)
        {
            SimpleResponse response = new SimpleResponse();

            if (command.Id == null || command.Id < 1)
            {
                response.ResponseCode = -100;
                response.ResponseMessage = "Invalid id value";
            }
            // Validation process will be added  in future.

            return response;
        }
    }
}