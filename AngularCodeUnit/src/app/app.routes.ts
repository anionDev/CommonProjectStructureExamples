import { Routes } from '@angular/router';
import { UserSettingsComponent } from './modules/user-settings/user-settings.component';

/** The routes of the application. */
export const routes: Routes = [
  { path: 'user/settings', component: UserSettingsComponent },
  { path: '', redirectTo: 'user/settings', pathMatch: 'full' }
];
