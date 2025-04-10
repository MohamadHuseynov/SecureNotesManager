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
            note.CreatedAt = DateTime.Now;
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public List<Note> GetAllNotes()
        {
            return _context.Notes.OrderByDescending(n => n.CreatedAt).ToList();
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

