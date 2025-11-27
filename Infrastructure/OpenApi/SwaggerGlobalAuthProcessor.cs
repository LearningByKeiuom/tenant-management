using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;
using System.Reflection;

namespace Infrastructure.OpenApi;

/// <summary>
    /// A custom operation processor for adding global authentication support in Swagger/OpenAPI.
    /// </summary>
    /// <param name="scheme">
    /// The authentication scheme to be applied. Defaults to <see cref="JwtBearerDefaults.AuthenticationScheme"/>.
    /// </param>
    public class SwaggerGlobalAuthProcessor(string scheme) : IOperationProcessor
    {
        private readonly string _scheme = scheme;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerGlobalAuthProcessor"/> class
        /// with the default authentication scheme (<see cref="JwtBearerDefaults.AuthenticationScheme"/>).
        /// </summary>
        public SwaggerGlobalAuthProcessor()
            : this(JwtBearerDefaults.AuthenticationScheme)
        {            
        }

        /// <summary>
        /// Processes the given operation to conditionally apply security requirements for Swagger documentation.
        /// </summary>
        /// <param name="context">The context containing operation and API metadata.</param>
        /// <returns>
        /// <c>true</c> if the processing is successful; otherwise, <c>false</c>.
        /// This implementation always returns <c>true</c>.
        /// </returns>
        /// <remarks>
        /// The processor checks for the presence of the <see cref="AllowAnonymousAttribute"/> 
        /// in the endpoint's metadata. If present, it skips adding security requirements.
        /// If not present and no security requirements exist, it adds a security requirement
        /// for the specified authentication scheme.
        /// </remarks>
        public bool Process(OperationProcessorContext context)
        {
            IList<object> list = ((AspNetCoreOperationProcessorContext)context)
                .ApiDescription.ActionDescriptor.TryGetPropertyValue<IList<object>>("EndpointMetadata");

            if (list is not null)
            {
                if (list.OfType<AllowAnonymousAttribute>().Any())
                {
                    return true;
                }

                if (context.OperationDescription.Operation.Security.Count == 0)
                {
                    (context.OperationDescription.Operation.Security ??= [])
                        .Add(new OpenApiSecurityRequirement
                        {
                            { 
                                _scheme,
                                Array.Empty<string>()
                            }
                        });
                }
            }
            return true;
        }
    }