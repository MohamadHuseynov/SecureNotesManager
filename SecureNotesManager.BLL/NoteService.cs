using SecureNotesManager.Models;
using SecureNotesManager.DAL;

namespace SecureNotesManager.BLL
{
    public class NoteService
    {
        private readonly SecureNotesDbContext _context;

        public NoteService()
        {
            _context = new SecureNotesDbContext();
        }

        public void AddNote(Note note)
        {
            note.Content = EncryptionHelper.Encrypt(note.Content);

            note.CreatedAt = DateTime.Now;
            note.ModifiedAt = DateTime.Now;

            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public List<Note> GetAllNotes()
        {
            var notes = _context.Notes.OrderByDescending(n => n.CreatedAt).ToList();

            foreach (var note in notes)
            {
                try
                {
                    note.Content = EncryptionHelper.Decrypt(note.Content);
                }
                catch
                {
                    // اگر رشته رمزنگاری نشده باشه، کاری نمی‌کنیم
                    // (همون متن ساده رو نشون می‌دیم)
                }
            }

            return notes;
        }



        public void DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

        public void UpdateNote(Note note)
        {
            note.Content = EncryptionHelper.Encrypt(note.Content);

            var existing = _context.Notes.Find(note.Id);
            if (existing != null)
            {
                existing.Title = note.Title;
                existing.Content = note.Content;
                existing.ModifiedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}

