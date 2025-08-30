import { promises as fs } from 'fs';
import { EventEmitter } from 'events';
import { fileURLToPath } from 'url';
import path from 'path';

const emitter = new EventEmitter();

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const dataFile = path.join(__dirname, '..', 'data', 'books.json');

async function readFile() {
  try {
    const content = await fs.readFile(dataFile, 'utf-8');
    return JSON.parse(content || '[]');
  } catch (err) {
    if (err.code === 'ENOENT') {
      await writeFile([]);
      return [];
    }
    throw err;
  }
}

async function writeFile(data) {
  await fs.writeFile(dataFile, JSON.stringify(data, null, 2), 'utf-8');
}

export async function getAllBooks() {
  return await readFile();
}

export async function getBookById(id) {
  const books = await readFile();
  return books.find(b => String(b.id) === String(id));
}

export async function addBook(book) {
  if (!book || !book.title || !book.author) {
    throw new Error('Book must have title and author');
  }
  const books = await readFile();
  const maxId = books.reduce((acc, b) => Math.max(acc, Number(b.id || 0)), 0);
  const newBook = { id: maxId + 1, title: book.title, author: book.author };
  books.push(newBook);
  await writeFile(books);
  emitter.emit('Book Added', newBook);
  return newBook;
}

export async function updateBook(id, updates) {
  const books = await readFile();
  const idx = books.findIndex(b => String(b.id) === String(id));
  if (idx === -1) return null;
  books[idx] = { ...books[idx], ...(updates.title ? { title: updates.title } : {}), ...(updates.author ? { author: updates.author } : {}) };
  await writeFile(books);
  emitter.emit('Book Updated', books[idx]);
  return books[idx];
}

export async function deleteBook(id) {
  const books = await readFile();
  const idx = books.findIndex(b => String(b.id) === String(id));
  if (idx === -1) return null;
  const [removed] = books.splice(idx, 1);
  await writeFile(books);
  emitter.emit('Book Deleted', removed);
  return removed;
}

export { emitter };
