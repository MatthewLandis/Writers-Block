import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WriteComponent } from './write/write.component';
import { ReadComponent } from './read/read.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '',  component: HomeComponent },
  { path: 'write', component: WriteComponent },
  { path: 'read', component: ReadComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
