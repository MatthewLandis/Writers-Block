import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IStory } from './app.model';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient) { }

  public getStories(): Observable<IStory> {
    return this.http.get<IStory>('/api/Story/GetStory');
  }

  public addStory(storyToAdd: IStory): Observable<boolean> {
    return this.http.post<boolean>('/api/Story/AddStory', storyToAdd);
  }

  public SearchStory(title: string): Observable<IStory> {
    return this.http.get<IStory>('/api/Story/SearchStory', {
      params: { title }
    });
  }

  public rando(): Observable<IStory> {
    return this.http.get<IStory>('/api/Story/Rando');
  }
}
