import { Component, signal } from '@angular/core';
import { GreetingsComponent } from '../components/greetings/greetings.component';
import { CounterComponent } from '../components/counter/counter.component';

@Component({
  selector: 'app-home',
  imports: [GreetingsComponent,CounterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
    Homemessage=signal("Hello from home components")
}
