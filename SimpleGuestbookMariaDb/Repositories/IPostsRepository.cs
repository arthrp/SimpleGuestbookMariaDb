using SimpleGuestbookMariaDb.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleGuestbookMariaDb.Repositories
{
    public interface IPostsRepository
    {
        List<PostDto> GetAll();
        void Add(PostDto post);
    }
}
