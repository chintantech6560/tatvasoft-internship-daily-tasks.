import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./header/header.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',//Custom HTML tag
  standalone: true,
  imports:  [HeaderComponent,CommonModule,FormsModule,RouterOutlet],
  templateUrl: './app.component.html',//HTML file
  styleUrl: './app.component.css'//CSS file
})
export class AppComponent {//this is the Class
  title = 'DemoApp';
  name='chintan'
  visibility= true

  list=['item1','item2','item3'];

  listener(){
    this.visibility=!this.visibility;
    console.log(this.store);
  }

  store='bbb'
}
