export interface Todo {
  id: string;
  title: string;
  completed: boolean;
  createdAt: string; // ISO date string
}

export type TodoFilter = 'all' | 'active' | 'completed';
