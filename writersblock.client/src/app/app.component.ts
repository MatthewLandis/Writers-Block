import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';
import { IStory } from './app.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public stories: IStory[] = [];

  constructor(private appService: AppService) {}

  ngOnInit() {
    this.appService.getStories().subscribe(
      (result) => {
        this.stories = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
