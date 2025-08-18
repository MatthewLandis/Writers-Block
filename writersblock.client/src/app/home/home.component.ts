import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { IStory } from '../app.model';

@Component({
  selector: 'app-home',
  standalone: false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  public storyToAdd: IStory = {
    title: '',
    text: '',
    author: '',
  }

  public story: IStory = {
    title: '',
    text: '',
    author: '',
  }

  constructor(private appService: AppService) { }

  ngOnInit() {
    this.fetchStories();
  }

  fetchStories() {
    this.appService.getStories().subscribe(
      (result) => {
        this.story = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
