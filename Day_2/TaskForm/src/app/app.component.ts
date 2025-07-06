import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TaskForm';
  store_text:string='';
  store_pass:string='';

  listener(){
    console.log(this.store_text);
    console.log(this.store_pass);
  }
}
