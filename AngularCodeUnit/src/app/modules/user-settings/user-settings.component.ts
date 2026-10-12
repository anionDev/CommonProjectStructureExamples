import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { NgxDarkmodeToggleButtonComponent } from '@aniondev/ngx-darkmode-toggle-button';

/** Example-page which shows how a setting of the user is offered. Here it is the color-scheme of the application. */
@Component({
  selector: 'app-user-settings',
  imports: [MatCardModule, NgxDarkmodeToggleButtonComponent],
  templateUrl: './user-settings.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrl: './user-settings.component.scss'
})
export class UserSettingsComponent {

}
