using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantToKnowNet.Common.ViewModels
{
    public class UserInfoViewModel
    {
        public required string Id { get; set; }
        public required string Email { get; set; }
        public required string Language { get; set; }
        public required DateTime ExpireDateTime { get; set; }
        public bool Expired => ExpireDateTime < DateTime.UtcNow;
    }
}
