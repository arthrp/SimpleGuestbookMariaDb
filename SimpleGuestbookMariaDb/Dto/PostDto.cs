using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMariaDb.Dto
{
    [Table("posts")]
    public class PostDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Posttext { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
