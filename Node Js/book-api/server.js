import express from 'express';
import bodyParser from 'body-parser';
import { getAllBooks, getBookById, addBook, updateBook, deleteBook, emitter } from './services/bookService.js';

const app = express();
const PORT = 3000;

app.use(bodyParser.json());

app.get('/', (req, res) => {
  res.json({ message: 'Welcome to Book Management API' });
});

app.get('/books', async (req, res) => {
  try {
    const books = await getAllBooks();
    res.json(books);
  } catch (err) {
    res.status(500).json({ error: 'Failed to read books' });
  }
});

app.get('/books/:id', async (req, res) => {
  try {
    const book = await getBookById(req.params.id);
    if (!book) return res.status(404).json({ error: 'Book not found' });
    res.json(book);
  } catch (err) {
    res.status(500).json({ error: 'Failed to get book' });
  }
});

app.post('/books', async (req, res) => {
  try {
    const newBook = await addBook(req.body);
    res.status(201).json(newBook);
  } catch (err) {
    res.status(400).json({ error: err.message });
  }
});

app.put('/books/:id', async (req, res) => {
  try {
    const updated = await updateBook(req.params.id, req.body);
    if (!updated) return res.status(404).json({ error: 'Book not found' });
    res.json(updated);
  } catch (err) {
    res.status(400).json({ error: err.message });
  }
});

app.delete('/books/:id', async (req, res) => {
  try {
    const deleted = await deleteBook(req.params.id);
    if (!deleted) return res.status(404).json({ error: 'Book not found' });
    res.json({ message: 'Book deleted', book: deleted });
  } catch (err) {
    res.status(500).json({ error: 'Failed to delete book' });
  }
});

emitter.on('Book Added', (b) => console.log('[Event] Book Added:', b));
emitter.on('Book Updated', (b) => console.log('[Event] Book Updated:', b));
emitter.on('Book Deleted', (b) => console.log('[Event] Book Deleted:', b));

app.listen(PORT, () => {
  console.log(`Server running on http://localhost:${PORT}`);
});
