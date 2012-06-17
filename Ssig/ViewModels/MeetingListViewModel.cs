using System;
using System.Collections.Generic;
using System.Linq;
using Ssig.Models;

namespace Ssig.ViewModels {
    public class MeetingListViewModel {
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}