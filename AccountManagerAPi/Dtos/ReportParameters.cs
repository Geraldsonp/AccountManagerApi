using System;

namespace AccountManagerAPi.Dtos
{
    public record ReportParameters
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
