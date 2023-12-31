﻿using Bot.Builder.Community.Adapters.ActionsSDK;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryBot
{
    public class ActionsSdkAdapterWithErrorHandler : ActionsSdkAdapter
    {
        public ActionsSdkAdapterWithErrorHandler(ILogger<ActionsSdkAdapter> logger, ActionsSdkAdapterOptions adapterOptions)
            : base(adapterOptions, logger)
        {
            OnTurnError = async (turnContext, exception) =>
            {
                // Log any leaked exception from the application.
                logger.LogError($"Exception caught : {exception.Message}");

                // Send a catch-all apology to the user.
                await turnContext.SendActivityAsync("Sorry, it looks like something went wrong.");
            };
        }
    }
}
