import { Component } from '@angular/core';
import { AppService } from '../app.service';
import { IStory } from '../app.model';
import { readableStreamLikeToAsyncGenerator } from 'rxjs/internal/util/isReadableStreamLike';

@Component({
  selector: 'app-write',
  standalone: false,
  templateUrl: './write.component.html',
  styleUrl: './write.component.css'
})
export class WriteComponent {

  public storyToAdd: IStory = {
    title: '',
    text: '',
    author: '',
  }

  constructor(private appService: AppService) { }

  addStory() {
    this.appService.addStory(this.storyToAdd).subscribe(
      (result) => {
        console.log('Added story to database');
        if (result) {
          window.location.href = '/read';
        } else {
          console.error("bad");
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
