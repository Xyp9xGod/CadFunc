using System;

namespace CadFunc.Domain.Entities
{
    internal class ApiExplorerSettingsAttribute : Attribute
    {
        public bool IgnoreApi { get; set; }
    }
}