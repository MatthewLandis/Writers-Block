import { Component, OnInit } from '@angular/core';
import { AppService } from '../app.service';
import { IStory } from '../app.model';

@Component({
  selector: 'app-read',
  standalone: false,
  templateUrl: './read.component.html',
  styleUrl: './read.component.css'
})
export class ReadComponent implements OnInit {

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

  searchTitle = '';

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

  SearchStory(title: string) {
    this.appService.SearchStory(this.searchTitle).subscribe(
      (result) => {
        console.log('searching');
        this.story = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  rando() {
    this.appService.rando().subscribe(
      (result) => {
        console.log('getting random story');
        this.story = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
