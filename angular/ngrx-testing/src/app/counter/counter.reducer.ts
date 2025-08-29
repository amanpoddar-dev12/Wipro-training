import { createReducer,on } from "@ngrx/store";
import { increment,decrement,reset, AddThree, AddTwo } from "./counter.actions";

export const initialState = 0;
export const counterReducer = createReducer(
  initialState,
  on(increment, (state) => state + 1),
  on(decrement, (state) => state - 1),
  on(reset, (state) => 0),
  on(AddThree, (state) => state + 3),
  on(AddTwo, (state) => state + 2)
);
