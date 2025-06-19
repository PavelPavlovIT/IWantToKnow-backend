using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantKnowNet.Data.Models
{
    internal class AnswersList
    {
        public required string QuestionId { get; set; }
        public string? Title { get; set; }
        public string? AnswerId { get; set; }
    }
}
