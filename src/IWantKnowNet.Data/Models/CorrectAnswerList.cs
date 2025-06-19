using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantKnowNet.Data.Models
{
    internal class CorrectAnswerList
    {
        public string? QuestionId { get; set; }
        public string? QuestionTitle { get; set; }
        public string? CorrectAnswerId { get; set; }
        public string? AnswerId { get; set; }
    }
}
