import { Routes } from '@angular/router';
import { CallbackComponent } from './callback/callback.component';

export const ROUTES: Routes = [
  { path: 'callback', component: CallbackComponent },
  { path: '**', redirectTo: '' }
];
