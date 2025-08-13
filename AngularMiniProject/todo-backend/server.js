import express from "express";
import cors from "cors";
import bodyParser from "body-parser";
import fs from "fs";
import path from "path";
import morgan from "morgan";
import { fileURLToPath } from "url";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const DATA_FILE = path.join(__dirname, "todos.json");

const app = express();
const PORT = 3000;

// Middlewares
app.use(cors());
app.use(bodyParser.json());
app.use(morgan("dev"));

// --- Helpers ---
function ensureDataFile() {
  if (!fs.existsSync(DATA_FILE)) {
    fs.writeFileSync(DATA_FILE, JSON.stringify([], null, 2));
  }
}

function loadTodos() {
  ensureDataFile();
  try {
    const raw = fs.readFileSync(DATA_FILE, "utf-8");
    return JSON.parse(raw);
  } catch (e) {
    console.error("Failed to read todos.json:", e);
    return [];
  }
}

function saveTodos(todos) {
  fs.writeFileSync(DATA_FILE, JSON.stringify(todos, null, 2));
}

function generateId() {
  // Simple unique-ish id
  return `${Date.now().toString(36)}-${Math.random().toString(36).slice(2, 8)}`;
}

// --- Routes ---

// GET /todos → Get all todos
app.get("/todos", (req, res) => {
  const todos = loadTodos();
  res.json(todos);
});

// POST /todos → Add a new todo (title, completed=false, createdAt)
app.post("/todos", (req, res) => {
  const { title } = req.body;

  if (typeof title !== "string" || !title.trim()) {
    return res.status(400).json({ error: "Title is required." });
  }

  const todos = loadTodos();
  const newTodo = {
    id: generateId(),
    title: title.trim(),
    completed: false,
    createdAt: new Date().toISOString(),
  };

  todos.push(newTodo);
  saveTodos(todos);

  res.status(201).json(newTodo);
});

// PUT /todos/:id → Update a todo’s title or completed status
app.put("/todos/:id", (req, res) => {
  const { id } = req.params;
  const { title, completed } = req.body;

  const todos = loadTodos();
  const idx = todos.findIndex((t) => t.id === id);
  if (idx === -1) return res.status(404).json({ error: "Todo not found." });

  if (title !== undefined) {
    if (typeof title !== "string" || !title.trim()) {
      return res.status(400).json({ error: "Invalid title." });
    }
    todos[idx].title = title.trim();
  }

  if (completed !== undefined) {
    if (typeof completed !== "boolean") {
      return res.status(400).json({ error: "completed must be boolean." });
    }
    todos[idx].completed = completed;
  }

  saveTodos(todos);
  res.json(todos[idx]);
});

// DELETE /todos/:id → Remove a todo
app.delete("/todos/:id", (req, res) => {
  const { id } = req.params;
  const todos = loadTodos();
  const idx = todos.findIndex((t) => t.id === id);
  if (idx === -1) return res.status(404).json({ error: "Todo not found." });

  const removed = todos.splice(idx, 1)[0];
  saveTodos(todos);
  res.json(removed);
});

// Health check (optional)
app.get("/health", (_req, res) => res.json({ ok: true }));

app.listen(PORT, () => {
  ensureDataFile();
  console.log(`✅ Todo API running on http://localhost:${PORT}`);
});
