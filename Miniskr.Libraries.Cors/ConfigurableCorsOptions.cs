using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;

namespace Miniskr.Libraries.Cors
{
    public class ConfigurableCorsOptions
    {
        public bool AnyOrigin { get; set; }
        public bool AnyHeader { get; set; }
        public bool AnyMethod { get; set; }
        public bool AllowCredentials { get; set; }

        public List<string> Origins { get; } = new List<string>();
        public List<string> Headers { get; } = new List<string>();
        public List<string> Methods { get; } = new List<string>();

        public CorsPolicy ToPolicy()
        {
            var builder = new CorsPolicyBuilder();

            if (AnyOrigin)
                builder.AllowAnyOrigin();
            if (AnyHeader)
                builder.AllowAnyHeader();
            if (AnyMethod)
                builder.AllowAnyMethod();
            if (AllowCredentials)
                builder.AllowCredentials();

            builder.WithOrigins(this.Origins.ToArray());
            builder.WithHeaders(this.Headers.ToArray());
            builder.WithMethods(this.Methods.ToArray());

            return builder.Build();
        }
    }
}
