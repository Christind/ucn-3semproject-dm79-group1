using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using Logging;
using Repository.Models;
using Repository.Resources;
using RestfulAPI.Services.Interfaces;

namespace RestfulAPI.Services
{
    public class BookmarkService : IBookmarkService
    {
        private BookmarkRepository _bookmarkRepo;

        public BookmarkService()
        {
            _bookmarkRepo = new BookmarkRepository();
        }

        public List<Bookmark> GetAllBookmarks()
        {
            try
            {
                return _bookmarkRepo.GetAllBookmarks().ToList();
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetAllBookmarks", 1, WebOperationContext.Current);
                return null;
            }
        }

        public Bookmark GetBookmarkById(string id)
        {
            try
            {
                int bookmarkId;
                if (Int32.TryParse(id, out bookmarkId))
                {
                    return _bookmarkRepo.GetBookmarkById(bookmarkId);
                }
                else
                {
                    throw new FormatException("The supplied id, is not of the datatype integer.");
                }
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public List<Bookmark> GetBookmarksByUser(string userId)
        {
            try
            {
                int id;
                if (Int32.TryParse(userId, out id))
                {
                    return _bookmarkRepo.GetBookmarksByUserId(id).ToList();
                }
                else
                {
                    throw new FormatException("The supplied id, is not of the datatype integer.");
                }
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return null;
            }
        }

        public bool CreateBookmark(Bookmark bookmark)
        {
            try
            {
                _bookmarkRepo.Insert(bookmark);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool DeleteBookmark(string id)
        {
            try
            {
                int bookmarkId;
                if (Int32.TryParse(id, out bookmarkId))
                {
                    _bookmarkRepo.Disable(bookmarkId);
                    return true;
                }
                else
                {
                    throw new FormatException("The supplied id, is not of the datatype integer.");
                }
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return false;
            }
        }

        public bool EditBookmark(Bookmark bookmark)
        {
            try
            {
                _bookmarkRepo.Update(bookmark);
                return true;
            }
            catch (Exception ex)
            {
                HandleLogging.LogMessage(ex, "GetBookmarkById", 1, WebOperationContext.Current);
                return false;
            }
        }
    }
}
