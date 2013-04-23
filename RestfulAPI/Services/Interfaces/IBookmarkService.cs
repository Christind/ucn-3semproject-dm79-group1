using System.Collections.Generic;
using System.ServiceModel;
using Repository.Models;

namespace RestfulAPI.Services.Interfaces
{
    [ServiceContract]
    public interface IBookmarkService
    {
        [OperationContract]
        List<Bookmark> GetAllBookmarks();

        [OperationContract]
        Bookmark GetBookmarkById(string id);

        [OperationContract]
        List<Bookmark> GetBookmarksByUser(string userId);

        [OperationContract]
        bool CreateBookmark(Bookmark bookmark);

        [OperationContract]
        bool DeleteBookmark(string id);

        [OperationContract]
        bool EditBookmark(Bookmark bookmark);
    }
}
