// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Bicep.Core.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.CommandLine.Invocation;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace Bicep.RegistryModuleTool.Commands
{
    public abstract class BaseCommandHandler : ICommandHandler
    {
        protected BaseCommandHandler(IFileSystem fileSystem, ILogger logger)
        {
            this.FileSystem = fileSystem;
            this.Logger = logger;
        }

        protected IFileSystem FileSystem { get; }

        protected ILogger Logger { get; }

        public virtual Task<int> InvokeAsync(InvocationContext context)
        {
            try
            {
                this.InvokeInternal(context);
            }
            catch (Exception exception)
            {
                switch (exception)
                {
                    case BicepException:
                    case IOException:
                    case UnauthorizedAccessException:
                        this.Logger.LogError("{message}", exception.Message);
                        break;

                    default:
                        this.Logger.LogError(exception, "Unexpected exception.");
                        break;
                }

                return Task.FromResult(1);
            }

            return Task.FromResult(0);
        }

        protected abstract void InvokeInternal(InvocationContext context);
    }
}
