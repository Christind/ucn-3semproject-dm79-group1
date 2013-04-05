using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    class BookmarkRepository
    {
        private BPDbContext db;

        public BookmarkRepository()
        {
            db = new BPDbContext();
        }

        public IQueryable<Bookmark> GetAllBookmarks()
        {
            return db.Bookmarks;
        }

        public Bookmark GetBookmarkById(int id)
        {
            return db.Bookmarks.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Bookmark> GetBookmarksByUserId(int userId)
        {
            return db.Bookmarks.Where(x => x.UserId == userId);
        }

        public void Insert(Bookmark bookmark)
        {
            db.Bookmarks.Add(bookmark);
            db.SaveChanges();
        }

        public void Update(Bookmark bookmark)
        {
            Bookmark rBookmark = GetBookmarkById(bookmark.ID);
            if (rBookmark == null)
                return;

            rBookmark.Description = bookmark.Description;
            rBookmark.IsActive = bookmark.IsActive;
            rBookmark.Title = bookmark.Title;
            db.SaveChanges();
        }

        public void Delete(Bookmark bookmark)
        {
            if (GetBookmarkById(bookmark.ID) == null)
                return;
            db.Bookmarks.Remove(bookmark);
            db.SaveChanges();
        }
    }
}
