import { Component, computed, effect, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Todo, TodoFilter } from './models/todo.model';
import { TodoService } from './services/todo.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // UI state
  todos = signal<Todo[]>([]);
  filter = signal<TodoFilter>('all');
  newTitle = signal('');
  editingId = signal<string | null>(null);
  editingTitle = signal('');

  filteredTodos = computed(() => {
    const f = this.filter();
    const list = this.todos();
    if (f === 'active') return list.filter(t => !t.completed);
    if (f === 'completed') return list.filter(t => t.completed);
    return list;
  });

  remainingCount = computed(() => this.todos().filter(t => !t.completed).length);

  constructor(private api: TodoService) {
    // Load on start
    this.refresh();

    // Debug watcher (optional)
    effect(() => {
      console.log('Todos changed:', this.todos());
    });
  }

  refresh() {
    this.api.getTodos().subscribe({
      next: (data) => this.todos.set(data),
      error: (err) => console.error(err)
    });
  }

  addTodo() {
    const title = this.newTitle().trim();
    if (!title) return;
    this.api.addTodo(title).subscribe({
      next: (t) => {
        this.todos.update(list => [t, ...list]);
        this.newTitle.set('');
      },
      error: (e) => console.error(e)
    });
  }

  toggle(todo: Todo) {
    this.api.updateTodo(todo.id, { completed: !todo.completed }).subscribe({
      next: (updated) => {
        this.todos.update(list => list.map(t => t.id === updated.id ? updated : t));
      }
    });
  }

  startEdit(todo: Todo) {
    this.editingId.set(todo.id);
    this.editingTitle.set(todo.title);
  }

  saveEdit(todo: Todo) {
    const title = this.editingTitle().trim();
    if (!title) {
      // if cleared, delete
      this.delete(todo);
      return;
    }
    this.api.updateTodo(todo.id, { title }).subscribe({
      next: (updated) => {
        this.todos.update(list => list.map(t => t.id === updated.id ? updated : t));
        this.editingId.set(null);
        this.editingTitle.set('');
      }
    });
  }

  cancelEdit() {
    this.editingId.set(null);
    this.editingTitle.set('');
  }

  delete(todo: Todo) {
    this.api.deleteTodo(todo.id).subscribe({
      next: () => this.todos.update(list => list.filter(t => t.id !== todo.id))
    });
  }

  clearCompleted() {
    // Requirement: clear completed todos (frontend loops DELETE)
    const completed = this.todos().filter(t => t.completed);
    if (!completed.length) return;
    // Fire deletes in parallel
    completed.forEach(t => {
      this.api.deleteTodo(t.id).subscribe({
        next: () => this.todos.update(list => list.filter(x => x.id !== t.id))
      });
    });
  }

  setFilter(f: TodoFilter) {
    this.filter.set(f);
  }

  // Keyboard helpers
  onNewTodoKeydown(ev: KeyboardEvent) {
    if (ev.key === 'Enter') this.addTodo();
  }

  onEditKeydown(todo: Todo, ev: KeyboardEvent) {
    if (ev.key === 'Enter') this.saveEdit(todo);
    if (ev.key === 'Escape') this.cancelEdit();
  }
}
