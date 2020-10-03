using SimpleGuestbookMariaDb.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMariaDb.Models
{
    public class GuestbookViewModel
    {
        public List<PostDto> AllPosts { get; set; }
    }
}
