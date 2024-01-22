using System;
using System.Collections.Generic;
using System.Text;

namespace WeCharge.Models.General
{
    /// <summary>
    /// A logged issue (could be a with a charger, or a booking, or other).
    /// </summary>
    public class Issue
    {
        public string ID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public enum IssueStatus
        {
            Active,

            /// <summary>
            /// The asset is no longer active and available for use,
            /// but it is not deleted.
            /// </summary>
            Archived
        }

    }
}
