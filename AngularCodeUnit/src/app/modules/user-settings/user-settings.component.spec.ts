import { ComponentFixture, TestBed } from '@angular/core/testing';
import { UserSettingsComponent } from './user-settings.component';

describe('UserSettingsComponent', () => {

  let fixture: ComponentFixture<UserSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserSettingsComponent],
    }).compileComponents();
    fixture = TestBed.createComponent(UserSettingsComponent);
    fixture.detectChanges();
  });

  it('is created', () => {
    expect(fixture.componentInstance).toBeTruthy();
  });

  it('shows the settings-card with its title', () => {
    const cardTitle: HTMLElement | null = fixture.nativeElement.querySelector('mat-card-title');
    expect(cardTitle?.textContent).toContain('Settings');
  });

  it('shows the color-scheme setting with its label and toggle-button', () => {
    const label: HTMLElement | null = fixture.nativeElement.querySelector('.setting-label');
    expect(label?.textContent).toContain('Color scheme');
    const toggleButton: HTMLElement | null = fixture.nativeElement.querySelector('ngx-darkmode-toggle-button');
    expect(toggleButton).toBeTruthy();
  });
});
